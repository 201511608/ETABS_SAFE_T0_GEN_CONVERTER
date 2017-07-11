'Credit to Paul Bourke (pbourke@swin.edu.au) for the original Fortran 77 Program :))
'Converted from the VB-Conversion by EluZioN (EluZioN@casesladder.com)
'Check out: http://astronomy.swin.edu.au/~pbourke/terrain/triangulate/
'You can use this code however you like providing the above credits remain in tact
'Code updated to VB2008 by Lance Lefebure (Lance@Lefebure.com) July 17, 2009

Module Delaunay
    Public Structure dVertex 'Points (Vertices)
        Dim x As Single
        Dim y As Single
        Dim z As Single
    End Structure
    Public Structure dTriangle 'Created Triangles, vv# are the vertex pointers
        Dim vv0 As Integer
        Dim vv1 As Integer
        Dim vv2 As Integer
    End Structure

    Public Const MaxVertices As Integer = 10000 'Set these as applicable
    Public Const MaxTriangles As Integer = MaxVertices * 3
    Public Vertex(MaxVertices + 2) As dVertex 'Our points, the extra 2 are for the 3 points of the supertriangle
    Public VertexCount As Integer = -1
    Public Triangle(MaxTriangles - 1) As dTriangle 'Our Created Triangles, -1 because it is zero based
    Public TriangleCount As Integer = -1
    Public Edges(1, -1) As Integer


    Public Sub AddVertex(ByVal x As Single, ByVal y As Single, ByVal z As Single)
        If VertexCount + 1 < MaxVertices Then
            VertexCount += 1
            Vertex(VertexCount).x = x
            Vertex(VertexCount).y = y
            Vertex(VertexCount).z = z
        End If
    End Sub
    Public Sub EmptyVertexList()
        VertexCount = -1
        ReDim Vertex(MaxVertices + 2) 'clears all the data out, although really not necessary
    End Sub


    Public Function CalculateTriangles() As String() 'These triangles are arranged in clockwise order.
        TriangleCount = -1
        Dim retstring() As String
        ReDim Edges(1, MaxTriangles * 3)
        Dim Nedge As Integer
        Dim j As Integer
        Dim k As Integer
        Dim inc As Boolean

        'For Super Triangle
        Dim xmin As Single = Vertex(0).x 'This is to allow calculation of the bounding triangle
        Dim xmax As Single = xmin
        Dim ymin As Single = Vertex(0).y
        Dim ymax As Single = ymin

        For i = 1 To VertexCount
            If Vertex(i).x < xmin Then xmin = Vertex(i).x
            If Vertex(i).x > xmax Then xmax = Vertex(i).x
            If Vertex(i).y < ymin Then ymin = Vertex(i).y
            If Vertex(i).y > ymax Then ymax = Vertex(i).y
        Next
        Dim dx As Single = xmax - xmin
        Dim dy As Single = ymax - ymin
        Dim dmax As Single = dy
        If dx > dy Then dmax = dx
        Dim xmid As Single = (xmax + xmin) / 2
        Dim ymid As Single = (ymax + ymin) / 2

        'Set up the supertriangle. This is a triangle which encompasses all the sample points.
        'The supertriangle coordinates are added to the end of the vertex list. The supertriangle is the first triangle in the triangle list.
        Vertex(VertexCount + 1).x = xmid - 2 * dmax
        Vertex(VertexCount + 1).y = ymid - dmax
        Vertex(VertexCount + 2).x = xmid
        Vertex(VertexCount + 2).y = ymid + 2 * dmax
        Vertex(VertexCount + 3).x = xmid + 2 * dmax
        Vertex(VertexCount + 3).y = ymid - dmax
        Triangle(0).vv0 = VertexCount + 1
        Triangle(0).vv1 = VertexCount + 2
        Triangle(0).vv2 = VertexCount + 3
        Dim ntri As Integer = 0

        'Include each point one at a time into the existing mesh
        For i = 0 To VertexCount
            Nedge = 0
            'Set up the edge buffer.
            'If the point (Vertex(i).x,Vertex(i).y) lies inside the circumcircle then the three edges of that triangle are added to the edge buffer.
            j = -1
            Do
                j += 1
                inc = InCircle(Vertex(i).x, Vertex(i).y, Vertex(Triangle(j).vv0).x, Vertex(Triangle(j).vv0).y, Vertex(Triangle(j).vv1).x, Vertex(Triangle(j).vv1).y, Vertex(Triangle(j).vv2).x, Vertex(Triangle(j).vv2).y)
                If inc Then
                    If Nedge + 2 > UBound(Edges, 2) Or j > MaxTriangles Then Exit Function 'Out of range
                    Edges(0, Nedge) = Triangle(j).vv0
                    Edges(1, Nedge) = Triangle(j).vv1
                    Edges(0, Nedge + 1) = Triangle(j).vv1
                    Edges(1, Nedge + 1) = Triangle(j).vv2
                    Edges(0, Nedge + 2) = Triangle(j).vv2
                    Edges(1, Nedge + 2) = Triangle(j).vv0
                    Nedge += 3
                    Triangle(j).vv0 = Triangle(ntri).vv0
                    Triangle(j).vv1 = Triangle(ntri).vv1
                    Triangle(j).vv2 = Triangle(ntri).vv2
                    j -= 1
                    ntri -= 1
                End If
            Loop While j < ntri

            'Tag multiple edges
            'Note: if all triangles are specified anticlockwise then all interior edges are opposite pointing in direction.
            If Nedge - 1 > UBound(Edges, 2) Then Exit Function 'Out of range
            For j = 0 To Nedge - 2
                If Not Edges(0, j) = -1 And Not Edges(1, j) = -1 Then
                    For k = j + 1 To Nedge - 1
                        If Not Edges(0, k) = -1 And Not Edges(1, k) = -1 Then
                            If Edges(0, j) = Edges(1, k) Then
                                If Edges(1, j) = Edges(0, k) Then
                                    Edges(0, j) = -1
                                    Edges(1, j) = -1
                                    Edges(0, k) = -1
                                    Edges(1, k) = -1
                                End If
                            End If
                        End If
                    Next k
                End If
            Next j

            'Form new triangles for the current point, Skipping over any tagged edges.
            'All edges are arranged in clockwise order.
            For j = 0 To Nedge - 1
                If Not Edges(0, j) = -1 And Not Edges(1, j) = -1 Then
                    ntri += 1
                    If j > UBound(Edges, 2) Or ntri > UBound(Triangle) Then Exit Function 'Out of range
                    Triangle(ntri).vv0 = Edges(0, j)
                    Triangle(ntri).vv1 = Edges(1, j)
                    Triangle(ntri).vv2 = i
                End If
            Next j
        Next


        'Remove triangles with supertriangle vertices. These are triangles which have a vertex number greater than NVERT
        j = -1
        Do
            j += 1
            If Triangle(j).vv0 > VertexCount Or Triangle(j).vv1 > VertexCount Or Triangle(j).vv2 > VertexCount Then
                Triangle(j).vv0 = Triangle(ntri).vv0
                Triangle(j).vv1 = Triangle(ntri).vv1
                Triangle(j).vv2 = Triangle(ntri).vv2
                j -= 1
                ntri -= 1
            End If
        Loop While j < ntri


        'Build Edge list from triangles
        Nedge = -1
        Dim a As Integer
        Dim b As Integer
        Dim c As Integer
        Dim ab As Boolean
        Dim bc As Boolean
        Dim ca As Boolean
        If ntri > -1 Then ReDim Edges(1, (ntri + 1) * 3) 'Just making sure this array is big enough
        ReDim retstring(ntri)

        For i = 0 To ntri
            ab = True
            bc = True
            ca = True
            a = Triangle(i).vv0
            b = Triangle(i).vv1
            c = Triangle(i).vv2
            retstring(i) = CStr(a) + "," + CStr(b) + "," + CStr(c)

            For j = 0 To Nedge
                If Edges(0, j) = a And Edges(1, j) = b Then ab = False
                If Edges(0, j) = b And Edges(1, j) = a Then ab = False

                If Edges(0, j) = b And Edges(1, j) = c Then bc = False
                If Edges(0, j) = c And Edges(1, j) = b Then bc = False

                If Edges(0, j) = c And Edges(1, j) = a Then ca = False
                If Edges(0, j) = a And Edges(1, j) = c Then ca = False
            Next
            If ab Then
                Nedge += 1
                Edges(0, Nedge) = a
                Edges(1, Nedge) = b
            End If
            If bc Then
                Nedge += 1
                Edges(0, Nedge) = b
                Edges(1, Nedge) = c
            End If
            If ca Then
                Nedge += 1
                Edges(0, Nedge) = c
                Edges(1, Nedge) = a
            End If
        Next
        ReDim Preserve Edges(1, Nedge)

        TriangleCount = ntri
        Return retstring
    End Function
    Private Function InCircle(ByRef xp As Integer, ByRef yp As Integer, ByRef x1 As Integer, ByRef y1 As Integer, ByRef x2 As Integer, ByRef y2 As Integer, ByRef x3 As Integer, ByRef y3 As Integer) As Boolean
        'Return TRUE if the point (xp,yp) lies inside the circumcircle
        'made up by points (x1,y1) (x2,y2) (x3,y3)
        'The circumcircle centre is returned in (xc,yc) and the radius r
        'NOTE: A point on the edge is inside the circumcircle

        Dim m1 As Single
        Dim m2 As Single
        Dim mx1 As Single
        Dim mx2 As Single
        Dim my1 As Single
        Dim my2 As Single
        Dim dx As Single
        Dim dy As Single
        Dim rsqr As Single
        Dim drsqr As Single
        Dim xc As Single
        Dim yc As Single
        InCircle = False

        If y1 = y2 And y2 = y3 Then
            'MsgBox("INCIRCUM - F - Points are coincident !!")
            Exit Function
        ElseIf y2 = y1 Then
            m2 = -(x3 - x2) / (y3 - y2)
            mx2 = (x2 + x3) / 2
            my2 = (y2 + y3) / 2
            xc = (x2 + x1) / 2
            yc = m2 * (xc - mx2) + my2
        ElseIf y3 = y2 Then
            m1 = -(x2 - x1) / (y2 - y1)
            mx1 = (x1 + x2) / 2
            my1 = (y1 + y2) / 2
            xc = (x3 + x2) / 2
            yc = m1 * (xc - mx1) + my1
        Else
            m1 = -(x2 - x1) / (y2 - y1)
            m2 = -(x3 - x2) / (y3 - y2)
            mx1 = (x1 + x2) / 2
            mx2 = (x2 + x3) / 2
            my1 = (y1 + y2) / 2
            my2 = (y2 + y3) / 2
            xc = (m1 * mx1 - m2 * mx2 + my2 - my1) / (m1 - m2)
            yc = m1 * (xc - mx1) + my1
        End If

        dx = x2 - xc
        dy = y2 - yc
        rsqr = dx * dx + dy * dy
        dx = xp - xc
        dy = yp - yc
        drsqr = dx * dx + dy * dy

        If drsqr <= rsqr Then InCircle = True
    End Function
    Private Function WhichSide(ByRef xp As Integer, ByRef yp As Integer, ByRef x1 As Integer, ByRef y1 As Integer, ByRef x2 As Integer, ByRef y2 As Integer) As Short
        'Determines which side of a line the point (xp,yp) lies.
        'The line goes from (x1,y1) to (x2,y2)
        'Returns -1 for a point to the left
        '         0 for a point on the line
        '        +1 for a point to the right

        Dim equation As Double = ((yp - y1) * (x2 - x1)) - ((y2 - y1) * (xp - x1))

        If equation > 0 Then
            WhichSide = -1
        ElseIf equation = 0 Then
            WhichSide = 0
        Else
            WhichSide = 1
        End If

    End Function


    Public Function FindZValue(ByVal x As Integer, ByVal y As Integer) As Single
        FindZValue = 0
        For i = 0 To TriangleCount
            If InTriangle(x, y, Triangle(i).vv0, Triangle(i).vv1, Triangle(i).vv2) = True Then
                FindZValue = PlanePoint(x, y, Vertex(Triangle(i).vv0), Vertex(Triangle(i).vv1), Vertex(Triangle(i).vv2))
                If FindZValue > 0 Then
                    Exit Function
                End If
            End If
        Next
    End Function
    Private Function InTriangle(ByVal x As Integer, ByVal y As Integer, ByVal v0 As Integer, ByVal v1 As Integer, ByVal v2 As Integer) As Boolean
        InTriangle = False
        Dim v0x As Single = Vertex(v0).x
        Dim v0y As Single = Vertex(v0).y
        Dim v1x As Single = Vertex(v1).x
        Dim v1y As Single = Vertex(v1).y
        Dim v2x As Single = Vertex(v2).x
        Dim v2y As Single = Vertex(v2).y
        Dim side1 As Single = WhichSide(x, y, v0x, v0y, v1x, v1y)
        Dim side2 As Single = WhichSide(x, y, v1x, v1y, v2x, v2y)
        Dim side3 As Single = WhichSide(x, y, v2x, v2y, v0x, v0y)

        If (side1 = 0) And (side2 = 0) Then InTriangle = True
        If (side1 = 0) And (side3 = 0) Then InTriangle = True
        If (side2 = 0) And (side3 = 0) Then InTriangle = True
        If (side1 = 0) And (side2 = side3) Then InTriangle = True
        If (side2 = 0) And (side1 = side3) Then InTriangle = True
        If (side3 = 0) And (side1 = side2) Then InTriangle = True
        If (side1 = side2) And (side2 = side3) Then InTriangle = True
    End Function
    Private Function PlanePoint(ByVal x As Double, ByVal y As Double, ByVal p1 As dVertex, ByVal p2 As dVertex, ByVal p3 As dVertex) As Double
        Dim a As Double = p1.y * (p2.z - p3.z) + p2.y * (p3.z - p1.z) + p3.y * (p1.z - p2.z)
        Dim b As Double = p1.z * (p2.x - p3.x) + p2.z * (p3.x - p1.x) + p3.z * (p1.x - p2.x)
        Dim c As Double = p1.x * (p2.y - p3.y) + p2.x * (p3.y - p1.y) + p3.x * (p1.y - p2.y)
        Dim d As Double = -p1.x * (p2.y * p3.z - p3.y * p2.z) - p2.x * (p3.y * p1.z - p1.y * p3.z) - p3.x * (p1.y * p2.z - p2.y * p1.z)

        If (Math.Abs(c) > 0.0001) Then
            PlanePoint = (-(a * x + b * y + d) / c)
        Else
            PlanePoint = 0
        End If
    End Function
End Module
