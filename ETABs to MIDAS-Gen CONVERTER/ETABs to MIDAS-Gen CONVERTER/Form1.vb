Imports System
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Text.RegularExpressions


Public Class Form1
    
    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    'SAFE TABLES
    ''' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Dim dtPCunits_read As New DataTable  '"PROGRAM CONTROL"
    Dim dtOGPC_read As New DataTable  '"OBJECT GEOMETRY - POINT COORDINATES"
    Dim dtOGL_read As New DataTable   '"OBJECT GEOMETRY - LINES 01 - GENERAL"
    Dim dtOGA_read As New DataTable   '"OBJECT GEOMETRY - AREAS 01 - GENERAL"
    Dim dtOGDS_read As New DataTable  '"OBJECT GEOMETRY - DESIGN STRIPS"
    Dim dtMPG_read As New DataTable  '"MATERIAL PROPERTIES 01 - GENERAL"
    Dim dtMPS_read As New DataTable  '"MATERIAL PROPERTIES 02 - STEEL"
    Dim dtMPC_read As New DataTable  '"MATERIAL PROPERTIES 03 - CONCRETE"
    Dim dtMPR_read As New DataTable  '"MATERIAL PROPERTIES 04 - REBAR"
    Dim dtMPT_read As New DataTable  '"MATERIAL PROPERTIES 05 - TENDON"
    Dim dtMPO_read As New DataTable  '"MATERIAL PROPERTIES 06 - OTHER"
    Dim dtSPG_read As New DataTable  '"SLAB PROPERTIES 01 - GENERAL"
    Dim dtSPSS_read As New DataTable '"SLAB PROPERTIES 02 - SOLID SLABS"
    Dim dtSPRW_read As New DataTable '"SLAB PROPERTIES 03 - RIBBED AND WAFFLE SLABS"
    Dim dtSP_read As New DataTable   '"SOIL PROPERTIES"
    Dim dtSPL_read As New DataTable   '"SPRING PROPERTIES - LINE"
    Dim dtSPP_read As New DataTable   '"SPRING PROPERTIES - POINT"
    Dim dtBPG_read As New DataTable   '"BEAM PROPERTIES 01 - GENERAL"
    Dim dtBPRB_read As New DataTable  '"BEAM PROPERTIES 02 - RECTANGULAR BEAM"
    Dim dtCPG_read As New DataTable   '"COLUMN PROPERTIES 01 - GENERAL"
    Dim dtCPR_read As New DataTable   '"COLUMN PROPERTIES 02 - RECTANGULAR"
    Dim dtWP_read As New DataTable    '"WALL PROPERTIES"
    Dim dtLP_read As New DataTable    '"LOAD PATTERNS"
    Dim dtLCG_read As New DataTable   ' "LOAD CASES 01 - GENERAL"
    Dim dtLCS_read As New DataTable   ' "LOAD CASES 02 - STATIC"
    Dim dtLCLA_read As New DataTable  ' "LOAD CASES 06 - LOADS APPLIED"
    Dim dtLC_read As New DataTable    '  "TABLE:  "LOAD COMBINATIONS"
    Dim dtSPA_read As New DataTable   '"SLAB PROPERTY ASSIGNMENTS"
    Dim dtBPA_read As New DataTable   '"BEAM PROPERTY ASSIGNMENTS"
    Dim dtBIP_read As New DataTable   '"BEAM INSERTION POINT"
    Dim dtCPA_read As New DataTable  '"COLUMN PROPERTY ASSIGNMENTS"
    Dim dtCLA_read As New DataTable  '"COLUMN LOCAL AXES"
    Dim dtCIP_read As New DataTable  '"COLUMN INSERTION POINT"
    Dim dtWPA_read As New DataTable  '"WALL PROPERTY ASSIGNMENTS"
    Dim dtPRA_read As New DataTable  '"POINT RESTRAINT ASSIGNMENTS"
    Dim dtLASL_read As New DataTable ' "LOAD ASSIGNMENTS - SURFACE LOADS"
    Dim dtLAPL_read As New DataTable '"LOAD ASSIGNMENTS - POINT LOADS"
    Dim dtPSA_read As New DataTable  '"POINT SPRING ASSIGNMENTS"
    Dim dtCPC_read As New DataTable  '"COLUMN PROPERTIES 03 - CIRCULAR"
    Dim dtBPTB_read As New DataTable '"BEAM PROPERTIES 03 - T BEAM"  
    Dim dtBPLB_read As New DataTable '"BEAM PROPERTIES 04 - L BEAM"
    Dim dtCPTS_read As New DataTable ' "COLUMN PROPERTIES 04 - T SHAPE"
    Dim dtCPLS_read As New DataTable '"COLUMN PROPERTIES 05 - L SHAPE"
    Dim dtSoilA_read As New DataTable '"SOIL PROPERTY ASSIGNMENTS"
    Dim dtLSA_read As New DataTable  '"LINE SPRING ASSIGNMENTS"
    Dim dtLALDL_read As New DataTable  '"LOAD ASSIGNMENTS - LINE OBJECTS - DISTRIBUTED LOADS"
    Dim dtLAPD_read As New DataTable '"LOAD ASSIGNMENTS - POINT DISPLACEMENT LOADS"
    ''' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''' SAFE_GEN TABLES
    Dim dtNODE_arrange As New DataTable         'NODE  ''
    Dim dtNODELOAD_arrange As New DataTable     'NODELOAD *CONLOAD  ''
    Dim dtMATERIAL_arrange As New DataTable     'MATERIAL PROPERTIES '
    Dim dtTHICKNESS_arrange As New DataTable    'Thickness   '
    Dim dtSPRINGPOINT_arrange As New DataTable  'SPRINGPOINT ''
    Dim dtCONSTRAIN_arrange As New DataTable    'CONSTRAIN    ''
    Dim dtPRESSURE_arrange As New DataTable     'PRESSURE LOAD  '
    Dim dtPRESSURE_arrange_RA As New DataTable   'PRESSURE LOAD ReAssigned for new  plates  '
    Dim dtSTLDCASE_arrange As New DataTable     'LOADCASE       '
    Dim dtBEAM_arrange As New DataTable         'BEAM ''
    Dim dtSECTION_arrange As New DataTable      'SECTION   '
    Dim dtPLATE_arrange As New DataTable        'PLATE  ''
    Dim dtSURFACESPRING_arrange As New DataTable    'SURFACESPRING   '
    Dim dtSURFACESPRING_arrange_RA As New DataTable 'SURFACESPRING Reassign for plates dtSURFACESPRING_arrange      '
    Dim dtBEAMLOAD_arrange As New DataTable 'BEAMLOAD
    Dim dtPOINTDISPLOAD_arrange As New DataTable 'NODAL DISPLACEMENT


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    'ETABS TABELS
    ''' ''''''''''''''''''''''''''''''''''''''
    Dim dtCrtdUnits As New DataTable
    Dim dtCrtdNode As New DataTable
    Dim dtCrtdElem_conn As New DataTable
    Dim dtCrtdElem As New DataTable
    Dim dtMatgrade As New DataTable
    Dim dtNodalLoads As New DataTable
    Dim dtLoadCases As New DataTable
    Dim dtStorydata As New DataTable

    Dim dtcrtdnodeorg As New DataTable
    Dim dtcrtdlineassign As New DataTable
    Dim dtcrtdstoryorg As New DataTable
    Dim node_passing As New DataTable
    Dim dtpointassign As New DataTable
    Dim dtboundary_conditions As New DataTable
    Dim dtload_pattern As New DataTable
    Dim dtbeam_loads As New DataTable
    Dim dtarea_assign As New DataTable
    Dim dtarea_conn As New DataTable
    Dim dtthickness As New DataTable
    Dim dtarea_ele_pass As New DataTable
    Dim dt_converter_table_node As New DataTable
    Dim dt_area_load_etabs As New DataTable
    Dim dt_area_load_type As New DataTable
    Dim dt_areaload_pass As New DataTable
    Dim dt_final_element_list As New DataTable
    Dim dt_loadset As New DataTable
    Dim dtProSection As New DataTable
    Dim dtProSectionUndef As New DataTable
    Dim dtmodifier As New DataTable
    Dim dt_pointspring As New DataTable
    Dim dt_springs As New DataTable

    Dim in_path As String
    Dim only_file_name As String
    Dim extension As String
    Dim out_path As String
    Dim out_path_2 As String
    Dim file_name As String
    Dim lines() As String
    Dim linesSAFE As String
    Dim line_count As Integer
    Dim story_height_sum As Single
    Dim nth_row As Integer

    Dim nodenumber As Integer
    Dim elementnumber As Integer
    Dim story_height As Single
    Dim no_story As Integer
    Dim once As Integer = 0
    Dim area_counter As Integer = 1
    Dim Connectivity_Count As Integer = 1
    Dim area_element_count_begin As Integer
    Dim node_count_infunc As Integer = 0
    Dim tot_org_nodes As Integer = 0
    Dim storydata_count As Integer = 0
    Dim final_plate_count_start As Integer = 0
    Dim code_ref As String = "NULL"

    '''''''''''''''''''''''''''''''''''''''''''''
    '''
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            'SAFE TABLES
            clear_checks()
            delete_db_SAFE()
            delete_db()
            ''' GEN_SAFE_TABLES
            ''' 
            '  dtLAPD    '"LOAD ASSIGNMENTS - POINT DISPLACEMENT LOADS"
            dtLAPD_read.Columns.Add("Point")
            dtLAPD_read.Columns.Add("LoadPat")
            dtLAPD_read.Columns.Add("Ux")
            dtLAPD_read.Columns.Add("Uy")
            dtLAPD_read.Columns.Add("Ugrav")
            dtLAPD_read.Columns.Add("Rx")
            dtLAPD_read.Columns.Add("Ry")
            dtLAPD_read.Columns.Add("Rz")



            '' dtPOINTDISPLOAD_arrange   
            dtPOINTDISPLOAD_arrange.Columns.Add("NODE_LIST")
            dtPOINTDISPLOAD_arrange.Columns.Add("FLAG")
            dtPOINTDISPLOAD_arrange.Columns.Add("Dx")
            dtPOINTDISPLOAD_arrange.Columns.Add("Dy")
            dtPOINTDISPLOAD_arrange.Columns.Add("Dz")
            dtPOINTDISPLOAD_arrange.Columns.Add("Rx")
            dtPOINTDISPLOAD_arrange.Columns.Add("Ry")
            dtPOINTDISPLOAD_arrange.Columns.Add("Rz")
            dtPOINTDISPLOAD_arrange.Columns.Add("REFERENCE")
            ''
            'dtBEAMLOAD      'SURFACESPRING Reassign for plates dtSURFACESPRING_arrange
            dtBEAMLOAD_arrange.Columns.Add("ELEM_LIST") '1
            dtBEAMLOAD_arrange.Columns.Add("CMD") ' , LINE  
            dtBEAMLOAD_arrange.Columns.Add("TYPE") ' , UNILOAD,
            dtBEAMLOAD_arrange.Columns.Add("DIR") ' GZ,
            dtBEAMLOAD_arrange.Columns.Add("GROUP_DATA_1")  ' YES, NO, aDir[1], , , , 
            dtBEAMLOAD_arrange.Columns.Add("D1")  '
            dtBEAMLOAD_arrange.Columns.Add("P1")  '
            dtBEAMLOAD_arrange.Columns.Add("D2")  '
            dtBEAMLOAD_arrange.Columns.Add("P2")  '
            dtBEAMLOAD_arrange.Columns.Add("GROUP_DATA_2")  '''' 
            dtBEAMLOAD_arrange.Columns.Add("REFERENCE")

            '  dtSURFACESPRING_arrange_RA 'SURFACESPRING Reassign for plates
            dtSURFACESPRING_arrange_RA.Columns.Add("ELEM_LIST")
            dtSURFACESPRING_arrange_RA.Columns.Add("Type")
            dtSURFACESPRING_arrange_RA.Columns.Add("iDIR")
            dtSURFACESPRING_arrange_RA.Columns.Add("WIDTH")
            dtSURFACESPRING_arrange_RA.Columns.Add("iSPR-TYPE")
            dtSURFACESPRING_arrange_RA.Columns.Add("MODULUSP")
            dtSURFACESPRING_arrange_RA.Columns.Add("GROUP")
            dtSURFACESPRING_arrange_RA.Columns.Add("SAFE_REFE")


            '''  dtSURFACESPRING_arrange  'SURFACESPRING
            dtSURFACESPRING_arrange.Columns.Add("ELEM_LIST")
            dtSURFACESPRING_arrange.Columns.Add("Type")
            dtSURFACESPRING_arrange.Columns.Add("iDIR")
            dtSURFACESPRING_arrange.Columns.Add("WIDTH")
            dtSURFACESPRING_arrange.Columns.Add("iSPR-TYPE")
            dtSURFACESPRING_arrange.Columns.Add("MODULUSP")
            dtSURFACESPRING_arrange.Columns.Add("GROUP")
            dtSURFACESPRING_arrange.Columns.Add("SAFE_REFE")


            ''' dtPLATE_arrange 
            dtPLATE_arrange.Columns.Add("iEL")
            dtPLATE_arrange.Columns.Add("TYPE")
            dtPLATE_arrange.Columns.Add("iMAT")
            dtPLATE_arrange.Columns.Add("iPRO")
            dtPLATE_arrange.Columns.Add("iN1")
            dtPLATE_arrange.Columns.Add("iN2")
            dtPLATE_arrange.Columns.Add("iN3")
            dtPLATE_arrange.Columns.Add("iN4")
            dtPLATE_arrange.Columns.Add("iSUB")
            dtPLATE_arrange.Columns.Add("iWID")
            dtPLATE_arrange.Columns.Add("Reference1")
            dtPLATE_arrange.Columns.Add("Reference2")



            '''  dtSECTION_arrange
            dtSECTION_arrange.Columns.Add("iSEC")
            dtSECTION_arrange.Columns.Add("TYPE") 'DBUSER
            dtSECTION_arrange.Columns.Add("SNAME") 'NAMES
            dtSECTION_arrange.Columns.Add("OFFSET_GROUP") ' CC, 0, 0, 0, 0, 0, 0, YES, NO,
            dtSECTION_arrange.Columns.Add("DB") 'SB
            dtSECTION_arrange.Columns.Add("NAME") '2 AS USER
            dtSECTION_arrange.Columns.Add("D1_D") 'DEPTH DIAMETER
            dtSECTION_arrange.Columns.Add("D2_B")
            dtSECTION_arrange.Columns.Add("D3")
            dtSECTION_arrange.Columns.Add("D4")
            dtSECTION_arrange.Columns.Add("D5")
            dtSECTION_arrange.Columns.Add("D6")
            dtSECTION_arrange.Columns.Add("D7")
            dtSECTION_arrange.Columns.Add("D8")
            dtSECTION_arrange.Columns.Add("D9")
            dtSECTION_arrange.Columns.Add("D10")


            ''' dtBEAM_arrange
            dtBEAM_arrange.Columns.Add("iEL")
            dtBEAM_arrange.Columns.Add("TYPEbLMT")
            dtBEAM_arrange.Columns.Add("iMAT")
            dtBEAM_arrange.Columns.Add("iPRO")
            dtBEAM_arrange.Columns.Add("iN1")
            dtBEAM_arrange.Columns.Add("iN2")
            dtBEAM_arrange.Columns.Add("ANGLE")
            dtBEAM_arrange.Columns.Add("iSUB")
            dtBEAM_arrange.Columns.Add("SAFE_Material_Referance")
            ''' dtSTLDCASE_arrange
            dtSTLDCASE_arrange.Columns.Add("LCNAME")
            dtSTLDCASE_arrange.Columns.Add("LCTYPE")
            dtSTLDCASE_arrange.Columns.Add("DESC")

            ''' dtPRESSURE
            dtPRESSURE_arrange.Columns.Add("ELEM_LIST")
            dtPRESSURE_arrange.Columns.Add("CMD")
            dtPRESSURE_arrange.Columns.Add("ETYP")
            dtPRESSURE_arrange.Columns.Add("iFACE")
            dtPRESSURE_arrange.Columns.Add("DIR")
            dtPRESSURE_arrange.Columns.Add("VX, VY, VZ")
            dtPRESSURE_arrange.Columns.Add("bPROJ")
            dtPRESSURE_arrange.Columns.Add("PU")
            dtPRESSURE_arrange.Columns.Add("P1, P2, P3, P4")
            dtPRESSURE_arrange.Columns.Add("SAFE_LoadPat")


            ''' dtPRESSURE_RA  Rearrange
            dtPRESSURE_arrange_RA.Columns.Add("ELEM_LIST")
            dtPRESSURE_arrange_RA.Columns.Add("CMD")
            dtPRESSURE_arrange_RA.Columns.Add("ETYP")
            dtPRESSURE_arrange_RA.Columns.Add("iFACE")
            dtPRESSURE_arrange_RA.Columns.Add("DIR")
            dtPRESSURE_arrange_RA.Columns.Add("VX, VY, VZ")
            dtPRESSURE_arrange_RA.Columns.Add("bPROJ")
            dtPRESSURE_arrange_RA.Columns.Add("PU")
            dtPRESSURE_arrange_RA.Columns.Add("P1, P2, P3, P4")
            dtPRESSURE_arrange_RA.Columns.Add("SAFE_LoadPat")


            ''' dtCONSTRAIN
            dtCONSTRAIN_arrange.Columns.Add("NODE_LIST")
            dtCONSTRAIN_arrange.Columns.Add("Dx")
            dtCONSTRAIN_arrange.Columns.Add("Dy")
            dtCONSTRAIN_arrange.Columns.Add("Dz")
            dtCONSTRAIN_arrange.Columns.Add("Rx")
            dtCONSTRAIN_arrange.Columns.Add("Ry")
            dtCONSTRAIN_arrange.Columns.Add("Rz")


            ''dtSPRINGPOINT
            dtSPRINGPOINT_arrange.Columns.Add("NODE_LIST")
            dtSPRINGPOINT_arrange.Columns.Add("Type")
            dtSPRINGPOINT_arrange.Columns.Add("SDx")
            dtSPRINGPOINT_arrange.Columns.Add("SDy")
            dtSPRINGPOINT_arrange.Columns.Add("SDz")
            dtSPRINGPOINT_arrange.Columns.Add("SRx")
            dtSPRINGPOINT_arrange.Columns.Add("SRy")
            dtSPRINGPOINT_arrange.Columns.Add("SRz")
            dtSPRINGPOINT_arrange.Columns.Add("GROUP")


            '''  THICKNESS
            dtTHICKNESS_arrange.Columns.Add("iTHK")
            dtTHICKNESS_arrange.Columns.Add("TYPE")
            dtTHICKNESS_arrange.Columns.Add("bSAME")
            dtTHICKNESS_arrange.Columns.Add("THIK-IN")
            dtTHICKNESS_arrange.Columns.Add("THIK-OUT")
            dtTHICKNESS_arrange.Columns.Add("bOFFSET")
            dtTHICKNESS_arrange.Columns.Add("OFFTYPE")
            dtTHICKNESS_arrange.Columns.Add("VALUE")
            dtTHICKNESS_arrange.Columns.Add("SAFE_NAME")

            ''' MATERIAL PROPERTIES
            ''' '; iMAT, TYPE, MNAME, SPHEAT, HEATCO, PLAST, TUNIT, bMASS, DAMPRATIO, [DATA1]           ; STEEL, CONC, USER
            dtMATERIAL_arrange.Columns.Add("iMAT")
            dtMATERIAL_arrange.Columns.Add("TYPE")
            dtMATERIAL_arrange.Columns.Add("MNAME")
            dtMATERIAL_arrange.Columns.Add("SPHEAT")
            dtMATERIAL_arrange.Columns.Add("HEATCO")

            dtMATERIAL_arrange.Columns.Add("PLAST")
            dtMATERIAL_arrange.Columns.Add("TUNIT")
            dtMATERIAL_arrange.Columns.Add("bMASS")
            dtMATERIAL_arrange.Columns.Add("DAMPRATIO")
            dtMATERIAL_arrange.Columns.Add("ELAST_or_2")
            dtMATERIAL_arrange.Columns.Add("ELAST")
            dtMATERIAL_arrange.Columns.Add("POISN")

            dtMATERIAL_arrange.Columns.Add("THERMAL")
            dtMATERIAL_arrange.Columns.Add("CODE")
            dtMATERIAL_arrange.Columns.Add("DEN")
            dtMATERIAL_arrange.Columns.Add("MASS")



            ''' dtNODELOAD_write

            dtNODELOAD_arrange.Columns.Add("NODE_LIST")
            dtNODELOAD_arrange.Columns.Add("FX")
            dtNODELOAD_arrange.Columns.Add("FY")
            dtNODELOAD_arrange.Columns.Add("FZ")
            dtNODELOAD_arrange.Columns.Add("MX")
            dtNODELOAD_arrange.Columns.Add("MY")
            dtNODELOAD_arrange.Columns.Add("MZ")
            dtNODELOAD_arrange.Columns.Add("GROUP")


            ''' dtNODE  'nodes
            dtNODE_arrange.Columns.Add("iNO")
            dtNODE_arrange.Columns.Add("X")
            dtNODE_arrange.Columns.Add("Y")
            dtNODE_arrange.Columns.Add("Z")
            dtNODE_arrange.Columns.Add("REFERENCE")



            '''SAFE
            ''' 
            ''' dtPCunits     '"PROGRAM CONTROL"
            dtPCunits_read.Columns.Add("Force")
            dtPCunits_read.Columns.Add("Dimension")
            dtPCunits_read.Columns.Add("Heat")
            dtPCunits_read.Columns.Add("Temperature")

            'OGPC   '"OBJECT GEOMETRY - POINT COORDINATES"
            dtOGPC_read.Columns.Add("Point")
            dtOGPC_read.Columns.Add("GlobalX")
            dtOGPC_read.Columns.Add("GlobalY")
            dtOGPC_read.Columns.Add("GlobalZ")
            dtOGPC_read.Columns.Add("SpecialPt")

            'OGL   '"OBJECT GEOMETRY - LINES 01 - GENERAL"
            dtOGL_read.Columns.Add("Line")
            dtOGL_read.Columns.Add("PointI")
            dtOGL_read.Columns.Add("PointJ")
            dtOGL_read.Columns.Add("LineType")
            dtOGL_read.Columns.Add("Length")
            dtOGL_read.Columns.Add("CurveType")

            'dtOGA   '"OBJECT GEOMETRY - AREAS 01 - GENERAL"
            dtOGA_read.Columns.Add("Area")
            dtOGA_read.Columns.Add("NumPoints")
            dtOGA_read.Columns.Add("Point1")
            dtOGA_read.Columns.Add("Point2")
            dtOGA_read.Columns.Add("Point3")
            dtOGA_read.Columns.Add("Point4")
            dtOGA_read.Columns.Add("Auto")
            dtOGA_read.Columns.Add("TotalArea")
            dtOGA_read.Columns.Add("AreaType")
            dtOGA_read.Columns.Add("CurvedEdges")

            'OGDS_read   '"OBJECT GEOMETRY - DESIGN STRIPS"
            dtOGDS_read.Columns.Add("Strip")
            dtOGDS_read.Columns.Add("Point")
            dtOGDS_read.Columns.Add("GlobalX")
            dtOGDS_read.Columns.Add("GlobalY")
            dtOGDS_read.Columns.Add("WALeft")
            dtOGDS_read.Columns.Add("WARight")


            'dtMPG  '"MATERIAL PROPERTIES 01 - GENERAL"
            dtMPG_read.Columns.Add("Material")
            dtMPG_read.Columns.Add("Type")
            dtMPG_read.Columns.Add("Color")
            dtMPG_read.Columns.Add("Notes")

            'dtMPC   '"MATERIAL PROPERTIES 02 - STEEL"
            dtMPS_read.Columns.Add("Material")
            dtMPS_read.Columns.Add("E")
            dtMPS_read.Columns.Add("U")
            dtMPS_read.Columns.Add("A")
            dtMPS_read.Columns.Add("UnitWt")
            dtMPS_read.Columns.Add("Fy")
            dtMPS_read.Columns.Add("Fu")

            'dtMPC   '"MATERIAL PROPERTIES 03 - CONCRETE"
            dtMPC_read.Columns.Add("Material")
            dtMPC_read.Columns.Add("E")
            dtMPC_read.Columns.Add("U")
            dtMPC_read.Columns.Add("A")
            dtMPC_read.Columns.Add("UnitWt")
            dtMPC_read.Columns.Add("Fc")
            dtMPC_read.Columns.Add("LtWtConc")

            'dtMPR      '"MATERIAL PROPERTIES 04 - REBAR"
            dtMPR_read.Columns.Add("Material")
            dtMPR_read.Columns.Add("E")
            dtMPR_read.Columns.Add("UnitWt")
            dtMPR_read.Columns.Add("Fy")
            dtMPR_read.Columns.Add("Fu")

            'dtMPT   '"MATERIAL PROPERTIES 05 - TENDON"
            dtMPT_read.Columns.Add("Material")
            dtMPT_read.Columns.Add("E")
            dtMPT_read.Columns.Add("UnitWt")
            dtMPT_read.Columns.Add("Fy")
            dtMPT_read.Columns.Add("Fu")

            'dtMPO    "MATERIAL PROPERTIES 06 - OTHER"
            dtMPO_read.Columns.Add("Material")
            dtMPO_read.Columns.Add("E")
            dtMPO_read.Columns.Add("U") 'POISSON RATION
            dtMPO_read.Columns.Add("A")
            dtMPO_read.Columns.Add("UnitWt")

            'dtSPG  '"SLAB PROPERTIES 01 - GENERAL"
            dtSPG_read.Columns.Add("Slab")
            dtSPG_read.Columns.Add("Type")
            dtSPG_read.Columns.Add("Color")

            'dtSPSS    '"SLAB PROPERTIES 02 - SOLID SLABS"
            dtSPSS_read.Columns.Add("Slab")
            dtSPSS_read.Columns.Add("Type")
            dtSPSS_read.Columns.Add("MatProp")
            dtSPSS_read.Columns.Add("Thickness")
            dtSPSS_read.Columns.Add("Ortho")

            'dtSPRW  "SLAB PROPERTIES 03 - RIBBED AND WAFFLE SLABS"
            dtSPRW_read.Columns.Add("Slab")
            dtSPRW_read.Columns.Add("Type")
            dtSPRW_read.Columns.Add("MatProp")
            dtSPRW_read.Columns.Add("TotalDepth")
            dtSPRW_read.Columns.Add("SlabThick")


            'dtSP     '"SOIL PROPERTIES"
            dtSP_read.Columns.Add("Soil")
            dtSP_read.Columns.Add("Subgrade")
            dtSP_read.Columns.Add("Color")

            'dtSPL     '"SPRING PROPERTIES - LINE"
            dtSPL_read.Columns.Add("Spring")
            dtSPL_read.Columns.Add("VertStiff")
            dtSPL_read.Columns.Add("RotStiff")
            dtSPL_read.Columns.Add("NonlinOpt")
            dtSPL_read.Columns.Add("Color")
            dtSPL_read.Columns.Add("Note")

            'dtSPP    '"SPRING PROPERTIES - POINT"
            dtSPP_read.Columns.Add("Spring")
            dtSPP_read.Columns.Add("Ux")
            dtSPP_read.Columns.Add("Uy")
            dtSPP_read.Columns.Add("Uz")
            dtSPP_read.Columns.Add("Rx")
            dtSPP_read.Columns.Add("Ry")
            dtSPP_read.Columns.Add("Rz")
            dtSPP_read.Columns.Add("NonlinOpt")
            dtSPP_read.Columns.Add("Color")

            'dtBPG    '"BEAM PROPERTIES 01 - GENERAL"
            dtBPG_read.Columns.Add("Beam")
            dtBPG_read.Columns.Add("Type")
            dtBPG_read.Columns.Add("Color")
            dtBPG_read.Columns.Add("Notes")

            'dtBPRB    '"BEAM PROPERTIES 02 - RECTANGULAR BEAM"
            dtBPRB_read.Columns.Add("Beam")
            dtBPRB_read.Columns.Add("MatProp")
            dtBPRB_read.Columns.Add("Depth")
            dtBPRB_read.Columns.Add("WidthTop")
            dtBPRB_read.Columns.Add("WidthBot")

            'dtCPG      '"COLUMN PROPERTIES 01 - GENERAL"
            dtCPG_read.Columns.Add("Column")
            dtCPG_read.Columns.Add("Type")
            dtCPG_read.Columns.Add("Color")
            dtCPG_read.Columns.Add("Notes")

            'dtCPR     '"COLUMN PROPERTIES 02 - RECTANGULAR"
            dtCPR_read.Columns.Add("Column")
            dtCPR_read.Columns.Add("MatProp")
            dtCPR_read.Columns.Add("SecDim2")
            dtCPR_read.Columns.Add("SecDim3")
            dtCPR_read.Columns.Add("AutoRigid")
            dtCPR_read.Columns.Add("AutoDrop")
            dtCPR_read.Columns.Add("DropDim2")
            dtCPR_read.Columns.Add("DropDim3")
            dtCPR_read.Columns.Add("DropProp")
            dtCPR_read.Columns.Add("IncludeCap")


            'dtWP     '"WALL PROPERTIES"
            dtWP_read.Columns.Add("Wall")
            dtWP_read.Columns.Add("MatProp")
            dtWP_read.Columns.Add("Thickness")
            dtWP_read.Columns.Add("AutoRigid")
            dtWP_read.Columns.Add("OutOfPlane")
            dtWP_read.Columns.Add("Color")
            dtWP_read.Columns.Add("Notes")


            'dtLP    "LOAD PATTERNS"
            dtLP_read.Columns.Add("LoadPat")
            dtLP_read.Columns.Add("Type")
            dtLP_read.Columns.Add("SelfWtMult")


            'dtLCG   ' "LOAD CASES 01 - GENERAL"
            dtLCG_read.Columns.Add("LoadCase")
            dtLCG_read.Columns.Add("Type")
            dtLCG_read.Columns.Add("DesignOpt")
            dtLCG_read.Columns.Add("DesignType")


            'dtLCS     ' "LOAD CASES 02 - STATIC"
            dtLCS_read.Columns.Add("LoadCase")
            dtLCS_read.Columns.Add("InitialCond")
            dtLCS_read.Columns.Add("AType")

            'dtLCLA    ' "LOAD CASES 06 - LOADS APPLIED"
            dtLCLA_read.Columns.Add("LoadCas")
            dtLCLA_read.Columns.Add("LoadPat")
            dtLCLA_read.Columns.Add("SF")

            ' dtLC     '  "TABLE:  "LOAD COMBINATIONS"
            dtLC_read.Columns.Add("Combo")
            dtLC_read.Columns.Add("Load")
            dtLC_read.Columns.Add("SF")
            dtLC_read.Columns.Add("Type")
            dtLC_read.Columns.Add("DSStrength")
            dtLC_read.Columns.Add("DSServInit")
            dtLC_read.Columns.Add("DSServNorm")
            dtLC_read.Columns.Add("DSServLong")
            dtLC_read.Columns.Add("AutoDesign")



            'dtSPA  ' Dim dtSPA_read As New DataTable   '"SLAB PROPERTY ASSIGNMENTS"
            dtSPA_read.Columns.Add("Area")
            dtSPA_read.Columns.Add("SlabProp")
            dtSPA_read.Columns.Add("OpeningType")



            'dtBPS 'Dim dtBPS_read As New DataTable   '"BEAM PROPERTY ASSIGNMENTS"
            dtBPA_read.Columns.Add("Line")
            dtBPA_read.Columns.Add("BeamProp")


            'dtBIP      ' Dim dtBIP_read As New DataTable   '"BEAM INSERTION POINT"
            dtBIP_read.Columns.Add("Line")
            dtBIP_read.Columns.Add("CardinalPt")
            dtBIP_read.Columns.Add("OffsetXI")
            dtBIP_read.Columns.Add("OffsetYI")
            dtBIP_read.Columns.Add("OffsetZI")
            dtBIP_read.Columns.Add("OffsetXJ")
            dtBIP_read.Columns.Add("OffsetYJ")
            dtBIP_read.Columns.Add("OffsetZJ")


            'dtCPA   Dim dtCPA_read As New DataTable  '"COLUMN PROPERTY ASSIGNMENTS"
            dtCPA_read.Columns.Add("Line")
            dtCPA_read.Columns.Add("ColProp")

            'dtCLA  Dim dtCLA_read As New DataTable  '"COLUMN LOCAL AXES"
            dtCLA_read.Columns.Add("Line")
            dtCLA_read.Columns.Add("Angle")


            ' dtCIP Dim dtCIP_read As New DataTable  '"COLUMN INSERTION POINT"
            dtCIP_read.Columns.Add("Line")
            dtCIP_read.Columns.Add("CardinalPt")
            dtCIP_read.Columns.Add("OffsetXI")
            dtCIP_read.Columns.Add("OffsetYI")
            dtCIP_read.Columns.Add("OffsetZI")
            dtCIP_read.Columns.Add("OffsetXJ")
            dtCIP_read.Columns.Add("OffsetYJ")
            dtCIP_read.Columns.Add("OffsetZJ")

            'dtWPA Dim dtWPA_read As New DataTable  '"WALL PROPERTY ASSIGNMENTS"
            dtWPA_read.Columns.Add("Area")
            dtWPA_read.Columns.Add("WallProp")

            'dtPRA Dim dtPRA_read As New DataTable  '"POINT RESTRAINT ASSIGNMENTS"
            dtPRA_read.Columns.Add("Point")
            dtPRA_read.Columns.Add("Ux")
            dtPRA_read.Columns.Add("Uy")
            dtPRA_read.Columns.Add("Uz")
            dtPRA_read.Columns.Add("Rx")
            dtPRA_read.Columns.Add("Ry")
            dtPRA_read.Columns.Add("Rz")

            ' dtLASL Dim dtLASL_read As New DataTable ' "LOAD ASSIGNMENTS - SURFACE LOADS"
            dtLASL_read.Columns.Add("Area")
            dtLASL_read.Columns.Add("LoadPat")
            dtLASL_read.Columns.Add("Dir")
            dtLASL_read.Columns.Add("UnifLoad")
            dtLASL_read.Columns.Add("A")
            dtLASL_read.Columns.Add("B")
            dtLASL_read.Columns.Add("C")

            'dtLAPL ' Dim dtLAPL_read As New DataTable '"LOAD ASSIGNMENTS - POINT LOADS"
            dtLAPL_read.Columns.Add("Point")
            dtLAPL_read.Columns.Add("LoadPat")
            dtLAPL_read.Columns.Add("Fx")
            dtLAPL_read.Columns.Add("Fy")
            dtLAPL_read.Columns.Add("Fgrav")
            dtLAPL_read.Columns.Add("Mx")
            dtLAPL_read.Columns.Add("My")
            dtLAPL_read.Columns.Add("Mz")
            dtLAPL_read.Columns.Add("XDim")
            dtLAPL_read.Columns.Add("YDim")


            ' dtPSA     '"POINT SPRING ASSIGNMENTS"
            dtPSA_read.Columns.Add("Point")
            dtPSA_read.Columns.Add("Spring")


            '   dtCPC   '"COLUMN PROPERTIES 03 - CIRCULAR"
            dtCPC_read.Columns.Add("Column")
            dtCPC_read.Columns.Add("MatProp")
            dtCPC_read.Columns.Add("Diameter")
            dtCPC_read.Columns.Add("AutoRigid")
            dtCPC_read.Columns.Add("AutoDrop")
            dtCPC_read.Columns.Add("IncludeCap")

            ' dtBPTB       '"BEAM PROPERTIES 03 - T BEAM"
            dtBPTB_read.Columns.Add("Beam")
            dtBPTB_read.Columns.Add("MatProp")
            dtBPTB_read.Columns.Add("TotalDepth")
            dtBPTB_read.Columns.Add("SlabDepth")
            dtBPTB_read.Columns.Add("FlngWidth")
            dtBPTB_read.Columns.Add("WidthTop")
            dtBPTB_read.Columns.Add("WidthBot")
            dtBPTB_read.Columns.Add("Inverted")


            'dtBPLB_read   '"BEAM PROPERTIES 04 - L BEAM"
            dtBPLB_read.Columns.Add("Beam")
            dtBPLB_read.Columns.Add("MatProp")
            dtBPLB_read.Columns.Add("TotalDepth")
            dtBPLB_read.Columns.Add("SlabDepth")
            dtBPLB_read.Columns.Add("FlngWidth")
            dtBPLB_read.Columns.Add("WidthTop")
            dtBPLB_read.Columns.Add("WidthBot")
            dtBPLB_read.Columns.Add("Inverted")

            'dtCPTS  '"COLUMN PROPERTIES 04 - T SHAPE"
            dtCPTS_read.Columns.Add("Column")
            dtCPTS_read.Columns.Add("MatProp")
            dtCPTS_read.Columns.Add("TotalDepth")
            dtCPTS_read.Columns.Add("FlngWidth")
            dtCPTS_read.Columns.Add("FlngThick")
            dtCPTS_read.Columns.Add("WebThick")
            dtCPTS_read.Columns.Add("AutoDrop")


            'dtCPLS '"COLUMN PROPERTIES 05 - L SHAPE
            dtCPLS_read.Columns.Add("Column")
            dtCPLS_read.Columns.Add("MatProp")
            dtCPLS_read.Columns.Add("TotalDepth")
            dtCPLS_read.Columns.Add("FlngWidth")
            dtCPLS_read.Columns.Add("FlngThick")
            dtCPLS_read.Columns.Add("WebThick")
            dtCPLS_read.Columns.Add("AutoDrop")


            'dtSoilA '"SOIL PROPERTY ASSIGNMENTS"
            dtSoilA_read.Columns.Add("Area")
            dtSoilA_read.Columns.Add("SoilProp")

            ' dtLSA_read   '"LINE SPRING ASSIGNMENTS"
            dtLSA_read.Columns.Add("Line")
            dtLSA_read.Columns.Add("Spring")

            ''' dtLALDL     "LOAD ASSIGNMENTS - LINE OBJECTS - DISTRIBUTED LOADS"
            dtLALDL_read.Columns.Add("Line")
            dtLALDL_read.Columns.Add("LoadPat")
            dtLALDL_read.Columns.Add("Type")
            dtLALDL_read.Columns.Add("Dir")
            dtLALDL_read.Columns.Add("DistType")
            dtLALDL_read.Columns.Add("RelDistA")
            dtLALDL_read.Columns.Add("RelDistB")
            dtLALDL_read.Columns.Add("AbsDistA")
            dtLALDL_read.Columns.Add("AbsDistB")
            dtLALDL_read.Columns.Add("FOverLA")
            dtLALDL_read.Columns.Add("FOverLB")





            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'ETABES_GEN_TABLES
            extension = Path.GetExtension(file_name)
            dtCrtdUnits.Columns.Add("Force", GetType(String)) '
            dtCrtdUnits.Columns.Add("Length", GetType(String)) '
            dtCrtdUnits.Columns.Add("Heat", GetType(String)) '
            dtCrtdUnits.Columns.Add("Temper", GetType(String)) '

            dtCrtdNode.Columns.Add("Node_Number") '
            dtCrtdNode.Columns.Add("X") '
            dtCrtdNode.Columns.Add("Y") '
            dtCrtdNode.Columns.Add("Z") '
            dtCrtdNode.Columns.Add("IS_PASSING") '
            dtCrtdNode.Columns.Add("Node_orignal") '
            dtCrtdNode.Columns.Add("Story_orignal") '

            dtCrtdElem_conn.Columns.Add("Element_Number", GetType(String))
            dtCrtdElem_conn.Columns.Add("Type", GetType(String))
            dtCrtdElem_conn.Columns.Add("N1", GetType(String))
            dtCrtdElem_conn.Columns.Add("N2", GetType(String))
            dtCrtdElem_conn.Columns.Add("Floor_var", GetType(String))

            dtCrtdElem.Columns.Add("Element_Number", GetType(String))
            dtCrtdElem.Columns.Add("Type", GetType(String))
            dtCrtdElem.Columns.Add("Section", GetType(String))
            dtCrtdElem.Columns.Add("Material", GetType(String))
            dtCrtdElem.Columns.Add("N1", GetType(String))
            dtCrtdElem.Columns.Add("N2", GetType(String))
            dtCrtdElem.Columns.Add("Floor_var", GetType(String))

            dtcrtdnodeorg.Columns.Add("Node_Number_org")
            dtcrtdnodeorg.Columns.Add("X1")
            dtcrtdnodeorg.Columns.Add("X2")
            dtcrtdnodeorg.Columns.Add("Z_dash")

            dtcrtdlineassign.Columns.Add("la_uq_elem", GetType(String))
            dtcrtdlineassign.Columns.Add("la_story", GetType(String))
            dtcrtdlineassign.Columns.Add("la_section", GetType(String))

            dtcrtdstoryorg.Columns.Add("Story_name")
            dtcrtdstoryorg.Columns.Add("Story_height")

            dtStorydata.Columns.Add("Story_name")
            dtStorydata.Columns.Add("Story_height")

            dtpointassign.Columns.Add("Node_Number")
            dtpointassign.Columns.Add("Floor")
            dtpointassign.Columns.Add("Restraint")

            dtboundary_conditions.Columns.Add("Node_Number")
            dtboundary_conditions.Columns.Add("Dx")
            dtboundary_conditions.Columns.Add("Dy")
            dtboundary_conditions.Columns.Add("Dz")
            dtboundary_conditions.Columns.Add("Rx")
            dtboundary_conditions.Columns.Add("Ry")
            dtboundary_conditions.Columns.Add("Rz")

            dtMatgrade.Columns.Add("Material_id")
            dtMatgrade.Columns.Add("Material_name")
            dtMatgrade.Columns.Add("Specific_Heat")
            dtMatgrade.Columns.Add("Heat_Conduction")
            dtMatgrade.Columns.Add("Damping_Ratio")
            dtMatgrade.Columns.Add("Modulus_Of_Elasticity")
            dtMatgrade.Columns.Add("Poisons_Ratio")
            dtMatgrade.Columns.Add("Thermal_Coeff")
            dtMatgrade.Columns.Add("Weight_Density")
            dtMatgrade.Columns.Add("Material_type")

            dtProSection.Columns.Add("Section_id")
            dtProSection.Columns.Add("Section_name")
            dtProSection.Columns.Add("Section_mat")
            dtProSection.Columns.Add("Section_mat_name")
            dtProSection.Columns.Add("Section_shape")
            dtProSection.Columns.Add("d1")
            dtProSection.Columns.Add("d2")
            dtProSection.Columns.Add("d3")
            dtProSection.Columns.Add("d4")
            dtProSection.Columns.Add("d5")
            dtProSection.Columns.Add("d6")
            dtProSection.Columns.Add("d7")
            dtProSection.Columns.Add("d8")

            dtProSectionUndef.Columns.Add("Section_id")
            dtProSectionUndef.Columns.Add("Section_name")
            dtProSectionUndef.Columns.Add("Section_mat")

            dtload_pattern.Columns.Add("Pattern_id")
            dtload_pattern.Columns.Add("Pattern_name")
            dtload_pattern.Columns.Add("Pattern_type")

            dtNodalLoads.Columns.Add("Node_id")
            dtNodalLoads.Columns.Add("Node_number")
            dtNodalLoads.Columns.Add("FX")
            dtNodalLoads.Columns.Add("FY")
            dtNodalLoads.Columns.Add("FZ")
            dtNodalLoads.Columns.Add("MX")
            dtNodalLoads.Columns.Add("MY")
            dtNodalLoads.Columns.Add("MZ")
            dtNodalLoads.Columns.Add("LC_NAME")

            dtbeam_loads.Columns.Add("Element_number")
            dtbeam_loads.Columns.Add("Loading_direction")
            dtbeam_loads.Columns.Add("d1")
            dtbeam_loads.Columns.Add("p1")
            dtbeam_loads.Columns.Add("d2")
            dtbeam_loads.Columns.Add("p2")
            dtbeam_loads.Columns.Add("d3")
            dtbeam_loads.Columns.Add("p3")
            dtbeam_loads.Columns.Add("d4")
            dtbeam_loads.Columns.Add("p4")
            dtbeam_loads.Columns.Add("LC_NAME")
            dtbeam_loads.Columns.Add("Type_to_print")
            dtbeam_loads.Columns.Add("Projection")

            dtarea_assign.Columns.Add("Area_name")
            dtarea_assign.Columns.Add("Area_story")
            dtarea_assign.Columns.Add("Area_section")

            dtarea_conn.Columns.Add("Connectivity_Count")
            dtarea_conn.Columns.Add("Material")
            dtarea_conn.Columns.Add("Property")
            dtarea_conn.Columns.Add("N1")
            dtarea_conn.Columns.Add("N2")
            dtarea_conn.Columns.Add("N3")
            dtarea_conn.Columns.Add("N4")
            dtarea_conn.Columns.Add("SUB")
            dtarea_conn.Columns.Add("WID")
            dtarea_conn.Columns.Add("Connectivity_name")
            dtarea_conn.Columns.Add("Connectivity_floor_chk")
            dtarea_conn.Columns.Add("chker")

            dtthickness.Columns.Add("Thickness_id")
            dtthickness.Columns.Add("Thickness_name")
            dtthickness.Columns.Add("Thickness_material")
            dtthickness.Columns.Add("Thickness_depth")

            dtarea_ele_pass.Columns.Add("Connectivity_Count") ''
            dtarea_ele_pass.Columns.Add("Material")
            dtarea_ele_pass.Columns.Add("Property")
            dtarea_ele_pass.Columns.Add("N1")
            dtarea_ele_pass.Columns.Add("N2")
            dtarea_ele_pass.Columns.Add("N3")
            dtarea_ele_pass.Columns.Add("N4")
            dtarea_ele_pass.Columns.Add("SUB")
            dtarea_ele_pass.Columns.Add("WID")
            dtarea_ele_pass.Columns.Add("Orignal_area_name")
            dtarea_ele_pass.Columns.Add("Orignal_area_story")
            dtarea_ele_pass.Columns.Add("chker")

            dt_area_load_etabs.Columns.Add("Area_name")
            dt_area_load_etabs.Columns.Add("Area_story")
            dt_area_load_etabs.Columns.Add("Area_type")
            dt_area_load_etabs.Columns.Add("Area_dir")
            dt_area_load_etabs.Columns.Add("Area_loadcase")
            dt_area_load_etabs.Columns.Add("Area_load_mag")

            dt_area_load_type.Columns.Add("Loadcase_name")
            dt_area_load_type.Columns.Add("Loadcase_name_area")
            dt_area_load_type.Columns.Add("Loadcase_name_story")
            dt_area_load_type.Columns.Add("Loadcase_name_dir")

            dt_areaload_pass.Columns.Add("Area_pass_name")
            dt_areaload_pass.Columns.Add("Area_pass_dir")
            dt_areaload_pass.Columns.Add("Area_pass_n1")
            dt_areaload_pass.Columns.Add("Area_pass_n2")
            dt_areaload_pass.Columns.Add("Area_pass_n3")
            dt_areaload_pass.Columns.Add("Area_pass_n4")

            dt_final_element_list.Columns.Add("Final_reference") ''
            dt_final_element_list.Columns.Add("Final_org_name")
            dt_final_element_list.Columns.Add("Final_org_story")

            dt_loadset.Columns.Add("Loadset_name")
            dt_loadset.Columns.Add("Loadset_pattern")
            dt_loadset.Columns.Add("Loadset_magnitude")

            dtmodifier.Columns.Add("mod_id")
            dtmodifier.Columns.Add("amod")
            dtmodifier.Columns.Add("a2mod")
            dtmodifier.Columns.Add("a3mod")
            dtmodifier.Columns.Add("jmod")
            dtmodifier.Columns.Add("i2mod")
            dtmodifier.Columns.Add("i3mod")
            dtmodifier.Columns.Add("mmod")
            dtmodifier.Columns.Add("wmod")

            dt_pointspring.Columns.Add("Spring_name")
            dt_pointspring.Columns.Add("UX")
            dt_pointspring.Columns.Add("UY")
            dt_pointspring.Columns.Add("UZ")
            dt_pointspring.Columns.Add("RX")
            dt_pointspring.Columns.Add("RY")
            dt_pointspring.Columns.Add("RZ")

            dt_springs.Columns.Add("Sp_node")
            dt_springs.Columns.Add("Sp_ux")
            dt_springs.Columns.Add("Sp_uy")
            dt_springs.Columns.Add("Sp_uz")
            dt_springs.Columns.Add("Sp_rx")
            dt_springs.Columns.Add("Sp_ry")
            dt_springs.Columns.Add("Sp_rz")



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If extension = ".$et" Or extension = ".e2k" Or extension = ".$ET" Or extension = ".E2K" Then
                ETABS()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf extension = ".f2k" Or extension = ".F2K" Then
                SAFE()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else
                MessageBox.Show("Wrong Extension")
                delete_db_SAFE()
                delete_db()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            MessageBox.Show("Error Encontered in line : " & lines(line_count))
            ProgressBar_read.Value = 0
            delete_db_SAFE()
            delete_db()
        End Try
    End Sub
    Private Sub browse_button_Click(sender As Object, e As EventArgs) Handles browse_button.Click
        ' MessageBox.Show("Make sure all the elements are USER DEFINED")
        OpenFileDialog.Title = "Enter the input file"
        OpenFileDialog.Filter = "ETABS/SAFE Text Files (*.$et, *e2k,*f2k)|*.$et;*.e2k;*.f2k|ETABS Text Files (*.$et,*e2k)|*.$et;*.e2k|SAFE Files (*f2k)|*.f2k|All Files (*.*)|*.*"
        OpenFileDialog.ShowDialog()
        file_name = OpenFileDialog.FileName()
        extension = Path.GetExtension(file_name) '''''''
        If file_name <> "NO_FILE_SELECTED" Then
            path_disp.Text = file_name
            in_path = Path.GetDirectoryName(file_name)
            only_file_name = Path.GetFileNameWithoutExtension(file_name) ' Limited extension
            If extension = ".$et" Or extension = ".e2k" Or extension = ".$ET" Or extension = ".E2K" Then
                only_file_name = Path.GetFileNameWithoutExtension(file_name)
                in_path = Path.GetDirectoryName(file_name)
                lines = File.ReadAllLines(file_name)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf extension = ".f2k" Or extension = ".F2K" Then
                lines = Split(File.ReadAllText(file_name), "TABLE:") ' Reading whole text

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            nodenumber = 1
            elementnumber = 1

        End If
        clear_checks()


        '    Application.DoEvents()
    End Sub
    Public Function clear_checks()
        units.Checked = False
        units.Enabled = False

        story.Checked = False
        story.Enabled = False

        points.Checked = False
        points.Enabled = False

        element_conn.Checked = False
        element_conn.Enabled = False

        element_conn.Checked = False
        element_conn.Enabled = False

        sections.Checked = False
        sections.Enabled = False

        constraints.Checked = False
        constraints.Enabled = False

        material.Checked = False
        material.Enabled = False

        section_assignment.Checked = False
        section_assignment.Enabled = False

        load_pattern.Checked = False
        load_pattern.Enabled = False

        point_loads.Checked = False
        point_loads.Enabled = False

        line_loads.Checked = False
        line_loads.Enabled = False

        area_ass.Checked = False
        area_ass.Enabled = False

        area_conn.Checked = False
        area_conn.Enabled = False

        thicknesses.Checked = False
        thicknesses.Enabled = False

        area_loading.Checked = False
        area_loading.Enabled = False

        unifloadset.Enabled = False
        unifloadset.Checked = False

        constraints.Checked = False
        constraints.Enabled = False

        point_disp_load.Checked = False
        point_disp_load.Enabled = False

        SURFACE_SPRING.Checked = False
        SURFACE_SPRING.Enabled = False

        POINT_SPRING.Checked = False
        POINT_SPRING.Enabled = False


    End Function
    Public Function parsing_units(ByVal parts() As String)
        If parts(1) = "LB" Then
            parts(1) = "LBF"
        End If
        dtCrtdUnits.Rows.Add(parts(1), parts(3), "BTU", parts(5))
    End Function
    Function ETABS()

        Dim Material_id As Integer = 1
        Dim sec_id As Integer = 1
        Dim loadpattern_id As Integer = 1
        Dim thickness_id_slab As Integer = 1
        Dim thickness_id_wall As Integer = 100
        Dim pointload_id As Integer = 1
        Dim Material_name As String
        Dim Specific_Heat As Double
        Dim Heat_Conduction As Double
        Dim Damping_Ratio As Double
        Dim Modulus_Of_Elasticity As Double
        Dim Poisons_Ratio As Double
        Dim Thermal_Coeff As Double
        Dim Weight_Density As Double
        Dim nodes As New List(Of String)()

        Dim lineload_ct As Integer = 0
        Dim p01 As Double
        Dim p02 As Double
        Dim p03 As Double
        Dim p04 As Double
        Dim p11 As Double
        Dim p12 As Double
        Dim p13 As Double
        Dim p14 As Double
        Dim p21 As Double
        Dim p22 As Double
        Dim p23 As Double
        Dim p24 As Double
        Dim prevpart As String = "123"
        Dim point_chk As Integer = 0

        Dim lnas_chk As Integer = 0
        Dim ll_chk As Integer = 0
        line_count = 0
        ProgressBar_read.Minimum = 0
        ProgressBar_read.Maximum = lines.Length() + lines.Length() / 10
        For i_main_read = 0 To lines.Count - 1
            If line_count < lines.Length() Then
                Dim parts() As String = lines(line_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)
                ProgressBar_read.Value = line_count
                If parts.Length > 1 Then
                    For conv = 0 To parts.Length - 1
                        parts(conv) = parts(conv).Trim()
                    Next

                    If parts(0) = "UNITS" Then
                        units.Checked = True
                        units.Enabled = True
                        If parts(3) = "MICRON" Then
                            MessageBox.Show("Length Units used in Input File are in Micron..not supported by midas GEN...Please Change the Input Units")
                            End
                        End If
                        parsing_units(parts)  ' Writes 
                    End If

                    If parts(0) = "STORY" Then
                        story.Checked = True
                        story.Enabled = True
                        Dim story_pass() As String = parts(2).Split(" ")
                        If parts(1).Length > 14 Then
                            parts(1) = parts(1)
                        End If
                        parsing_story(parts(1), story_pass(1))
                        once = 1
                    End If

                    If once = 1 And parts(0) <> "STORY" Then
                        rearrange_story(dtcrtdstoryorg)
                        once = 2
                    End If

                    If parts(0) = "POINT" Then
                        points.Checked = True
                        points.Enabled = True
                        Dim pt_pass() As String = parts(2).Split(" ")
                        Dim pt0 As Double = Convert.ToDouble(pt_pass(0))
                        Dim pt1 As Double = Convert.ToDouble(pt_pass(1))
                        pt_pass(0) = Math.Round(pt0, 3, MidpointRounding.AwayFromZero)
                        pt_pass(1) = Math.Round(pt1, 3, MidpointRounding.AwayFromZero)
                        If pt_pass.Count = 2 Then
                            dtcrtdnodeorg.Rows.Add(parts(1), pt_pass(0), pt_pass(1), 0)
                        End If
                        If pt_pass.Count = 3 Then
                            dtcrtdnodeorg.Rows.Add(parts(1), pt_pass(0), pt_pass(1), pt_pass(2))
                        End If
                        point_chk = 1
                    End If

                    If parts(0) <> "POINT" And point_chk = 1 Then
                        nodenumber = 1
                        tot_org_nodes = dtcrtdnodeorg.Rows.Count
                        For l1 = 0 To dtStorydata.Rows.Count - 1
                            For l2 = 0 To dtcrtdnodeorg.Rows.Count - 1
                                parsing_node(nodenumber, dtcrtdnodeorg.Rows(l2).Item("X1"), dtcrtdnodeorg.Rows(l2).Item("X2"), dtStorydata.Rows(l1).Item("Story_height") - dtcrtdnodeorg.Rows(l2).Item("Z_dash"), dtcrtdnodeorg.Rows(l2).Item("Node_Number_org"), dtStorydata.Rows(l1).Item("Story_name"))
                                nodenumber = nodenumber + 1
                            Next
                        Next
                        point_chk = 0
                        storydata_count = dtStorydata.Rows.Count - 1
                        node_count_infunc = dtCrtdNode.Rows.Count - 1
                    End If

                    If parts(0) = "LINE" Then
                        element_conn.Checked = True
                        element_conn.Enabled = True
                        parsing_elem_conn(parts(1), parts(3), parts(5), parts(6))
                    End If

                    If parts(0) = "LINEASSIGN" Then
                        sections.Checked = True
                        sections.Enabled = True
                        If parts(4) = "SECTION" Then
                            parsing_lineassign(parts(1), parts(3), parts(5))
                        End If

                    End If

                    If parts(0) = "POINTASSIGN" Then
                        constraints.Checked = True
                        constraints.Enabled = True
                        Dim lastnonempty As Integer = -1
                        For k As Integer = 0 To parts.Count - 1
                            If parts(k) <> "" Then
                                lastnonempty = lastnonempty + 1
                                parts(lastnonempty) = parts(k)
                            End If
                        Next
                        If lastnonempty < 0 Then
                            lastnonempty = 0
                        End If
                        ReDim Preserve parts(lastnonempty)

                        For ii = 0 To parts.Count - 1
                            parts(ii) = parts(ii).Trim
                        Next
                        If parts(3) = "RESTRAINT" Then
                            Dim dx As String = 0
                            Dim dy As String = 0
                            Dim dz As String = 0
                            Dim rx As String = 0
                            Dim ry As String = 0
                            Dim rz As String = 0

                            Dim bc_pass() As String = parts(4).Split(" ")
                            For i_bc = 0 To bc_pass.Length - 1

                                If bc_pass(i_bc) = "UX" Then
                                    dx = 1
                                End If
                                If bc_pass(i_bc) = "UY" Then
                                    dy = 1
                                End If
                                If bc_pass(i_bc) = "UZ" Then
                                    dz = 1
                                End If
                                If bc_pass(i_bc) = "RX" Then
                                    rx = 1
                                End If
                                If bc_pass(i_bc) = "RY" Then
                                    ry = 1
                                End If
                                If bc_pass(i_bc) = "RZ" Then
                                    rz = 1
                                End If
                            Next
                            parsing_pointassign(parts(1), parts(2), dx, dy, dz, rx, ry, rz)
                        End If

                        If parts(3) = "SPRINGPROP" Then
                            parsing_pointassign_spring(parts(1), parts(2), parts(4))
                        End If
                    End If

                    If parts(0) = "MATERIAL" Then
                        Dim Mat_count As Integer = 0    ''
                        Dim Mat_name As String = parts(1)  ''

                        material.Checked = True
                        material.Enabled = True
                        Dim material_type As String = "USER"
                        If parts(3) = "Rebar" Then
                            For inline = 0 To 1 '3
                                Dim parts_inline_mat() As String = lines(line_count + inline).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)
                                For conv = 0 To parts_inline_mat.Length - 1
                                    parts_inline_mat(conv) = parts_inline_mat(conv).Trim()
                                Next
                                If inline = 0 Then
                                    Material_name = parts_inline_mat(1)
                                    If Material_name.Length > 14 Then
                                        Material_name = Material_name
                                    End If
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(parts.Count - 1).Split(" ")
                                    Weight_Density = parts_inline_mat_split(1)
                                End If
                                If inline = 1 Then
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(parts.Count - 1).Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                                    Modulus_Of_Elasticity = parts_inline_mat_split(1)
                                    Thermal_Coeff = parts_inline_mat_split(3)
                                    Poisons_Ratio = 0.2
                                End If
                            Next
                            Specific_Heat = 0
                            Heat_Conduction = 0
                            Damping_Ratio = 0.05

                            While True
                                If lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries).Length > 2 Then
                                    If Mat_name = lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)(1) Then
                                        Mat_count = Mat_count + 1
                                    Else
                                        Exit While
                                    End If
                                Else
                                    Exit While
                                End If
                            End While

                            line_count = line_count + (Mat_count - 1)



                        ElseIf parts(3) = "Concrete" Then

                            material_type = "CONC"
                            For inline = 0 To 1 '3
                                Dim parts_inline_mat() As String = lines(line_count + inline).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)
                                For conv = 0 To parts_inline_mat.Length - 1
                                    parts_inline_mat(conv) = parts_inline_mat(conv).Trim()
                                Next
                                If inline = 0 Then
                                    Material_name = parts_inline_mat(1)
                                    If Material_name.Length > 14 Then
                                        Material_name = Material_name
                                    End If
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(parts.Count - 1).Split(" ")
                                    Weight_Density = parts_inline_mat_split(1)
                                End If
                                If inline = 1 Then
                                    Dim parts_inline_mat_split() As String
                                    If parts(4) = "NOTES" Then
                                        Dim parts_inline_mat1() As String = lines(line_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)
                                        parts_inline_mat_split = parts_inline_mat1(6).Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                                        Weight_Density = parts_inline_mat_split(1)
                                    Else
                                        parts_inline_mat_split = parts_inline_mat(parts.Count - 1).Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                                        Modulus_Of_Elasticity = parts_inline_mat_split(1)
                                        Thermal_Coeff = parts_inline_mat_split(5)
                                        Poisons_Ratio = parts_inline_mat_split(3)
                                    End If

                                End If
                            Next

                            Specific_Heat = 0
                            Heat_Conduction = 0
                            Damping_Ratio = 0.05

                            While True
                                If lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries).Length > 2 Then
                                    If Mat_name = lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)(1) Then
                                        Mat_count = Mat_count + 1
                                    Else
                                        Exit While
                                    End If
                                Else
                                    Exit While
                                End If
                            End While

                            line_count = line_count + (Mat_count - 1)

                        ElseIf parts(3) = "Steel" Then
                            material_type = "STEEL"
                            For inline = 0 To 1 '3
                                Dim parts_inline_mat() As String = lines(line_count + inline).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)
                                For conv = 0 To parts_inline_mat.Length - 1
                                    parts_inline_mat(conv) = parts_inline_mat(conv).Trim()
                                Next
                                If inline = 0 Then
                                    Material_name = parts_inline_mat(1)
                                    If Material_name.Length > 14 Then
                                        Material_name = Material_name
                                    End If
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(parts.Count - 1).Split(" ")
                                    Weight_Density = parts_inline_mat_split(1)
                                End If
                                If inline = 1 Then
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(parts.Count - 1).Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                                    Modulus_Of_Elasticity = parts_inline_mat_split(1)
                                    Thermal_Coeff = parts_inline_mat_split(5)
                                    Poisons_Ratio = parts_inline_mat_split(3)
                                End If
                            Next

                            Specific_Heat = 0
                            Heat_Conduction = 0
                            Damping_Ratio = 0.05
                            While True
                                If lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries).Length > 2 Then
                                    If Mat_name = lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)(1) Then
                                        Mat_count = Mat_count + 1
                                    Else
                                        Exit While
                                    End If
                                Else
                                    Exit While
                                End If
                            End While

                            line_count = line_count + (Mat_count - 1)


                        ElseIf parts(3) = "Tendon" Then
                            material_type = "STEEL"
                            For inline = 0 To 1 '3
                                Dim parts_inline_mat() As String = lines(line_count + inline).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)
                                For conv = 0 To parts_inline_mat.Length - 1
                                    parts_inline_mat(conv) = parts_inline_mat(conv).Trim()
                                Next
                                If inline = 0 Then
                                    Material_name = parts_inline_mat(1)
                                    If Material_name.Length > 14 Then
                                        Material_name = Material_name
                                    End If
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(parts.Count - 1).Split(" ")
                                    Weight_Density = parts_inline_mat_split(1)
                                End If
                                If inline = 1 Then
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(parts.Count - 1).Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                                    Modulus_Of_Elasticity = parts_inline_mat_split(1)
                                    'Thermal_Coeff = parts_inline_mat_split(5)
                                    Poisons_Ratio = parts_inline_mat_split(3)
                                End If
                            Next

                            Specific_Heat = 0
                            Heat_Conduction = 0
                            Damping_Ratio = 0.05
                            While True
                                If lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries).Length > 2 Then
                                    If Mat_name = lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)(1) Then
                                        Mat_count = Mat_count + 1
                                    Else
                                        Exit While
                                    End If
                                Else
                                    Exit While
                                End If
                            End While

                            line_count = line_count + (Mat_count - 1)

                        ElseIf parts(3) = "Other" Then
                            For inline = 0 To 1 '6
                                Dim parts_inline_mat() As String = lines(line_count + inline).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)
                                For conv = 0 To parts_inline_mat.Length - 1
                                    parts_inline_mat(conv) = parts_inline_mat(conv).Trim()
                                Next
                                If inline = 0 Then
                                    Material_name = parts_inline_mat(1)
                                    If Material_name.Length > 14 Then
                                        Material_name = Material_name
                                    End If
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(4).Split(" ")
                                    If parts_inline_mat_split.Length < 2 Then
                                        parts_inline_mat_split = parts_inline_mat(6).Split(" ")
                                        Weight_Density = parts_inline_mat_split(1)
                                    Else
                                        Weight_Density = parts_inline_mat_split(1)
                                    End If

                                End If
                                If inline = 1 Then
                                    Dim parts_inline_mat_split() As String = parts_inline_mat(4).Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                                    Modulus_Of_Elasticity = parts_inline_mat_split(1)
                                    Thermal_Coeff = parts_inline_mat_split(5)
                                    Poisons_Ratio = parts_inline_mat_split(3)
                                End If
                            Next

                            Specific_Heat = 0
                            Heat_Conduction = 0
                            Damping_Ratio = 0.05
                            While True
                                If lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries).Length > 2 Then
                                    If Mat_name = lines(line_count + Mat_count).Split(New Char() {""""}, StringSplitOptions.RemoveEmptyEntries)(1) Then
                                        Mat_count = Mat_count + 1
                                    Else
                                        Exit While
                                    End If
                                Else
                                    Exit While
                                End If
                            End While

                            line_count = line_count + (Mat_count - 1)
                        End If
                        parsing_material(Material_id, Material_name, Specific_Heat, Heat_Conduction, Damping_Ratio, Modulus_Of_Elasticity, Poisons_Ratio, Thermal_Coeff, Weight_Density, material_type)
                        Material_id = Material_id + 1

                    End If

                    If parts(0) = "FRAMESECTION" Then
                        Dim lastnonempty As Integer = -1
                        For k As Integer = 0 To parts.Count - 1
                            If parts(k) <> "" Then
                                lastnonempty = lastnonempty + 1
                                parts(lastnonempty) = parts(k)
                            End If
                        Next
                        If lastnonempty < 0 Then
                            lastnonempty = 0
                        End If
                        ReDim Preserve parts(lastnonempty)
                        section_assignment.Checked = True
                        section_assignment.Enabled = True
                        If parts.Count > 5 Then
                            If parts(5) <> "SD Section" And parts.Count > 6 Then
                                If parts(6) <> "FILE" Then
                                    Dim parts_dim() As String = parts(6).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                    Dim parts_shape() As String = parts(5).Split(" ")
                                    If parts(1).Length > 14 Then
                                        parts(1) = parts(1)
                                    End If
                                    If parts(5) = "Concrete Circle" Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), 0, 0, 0, 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf CStr(parts(5)).IndexOf("Concrete Rectangular") > -1 Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), 0, 0, 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf parts(5) = "Steel I/Wide Flange" Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), parts_dim(5), parts_dim(7), 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf parts(5) = "Steel Channel" Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), parts_dim(5), parts_dim(7), 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf parts(5) = "Steel Tee" Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), parts_dim(5), parts_dim(7), 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf parts(5) = "Steel Angle" Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), parts_dim(5), parts_dim(7), 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf parts(5) = "Steel Double Channel" Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), parts_dim(5), parts_dim(7), parts_dim(9), 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf parts(5) = "Steel Double Angle" Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), parts_dim(5), parts_dim(7), parts_dim(9), 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf parts(5) = "Steel Pipe" Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), 0, 0, 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf CStr(parts(5)).IndexOf("Concrete Encasement Rectangle") > -1 Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), 0, 0, 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf CStr(parts(5)).IndexOf("Filled Steel Tube") > -1 Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), parts_dim(5), parts_dim(7), 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf CStr(parts(5)).IndexOf("Filled Steel Pipe") > -1 Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), 0, 0, 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    ElseIf CStr(parts(5)).IndexOf("Steel Tube") > -1 Then
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), parts_dim(5), parts_dim(7), 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    Else
                                        parsing_section(sec_id, parts(1), parts(3), parts_shape(0), parts(5), parts_dim(1), parts_dim(3), 0, 0, 0, 0, 0, 0)
                                        sec_id = sec_id + 1
                                    End If
                                Else
                                    parsing_section(sec_id, parts(1), parts(3), "Steel", "Undefined", 0.1, 0.1, 0, 0, 0, 0, 0, 0)
                                    sec_id = sec_id + 1
                                End If
                            Else
                                parsing_section(sec_id, parts(1), "STEEL", "Steel", "Undefined", 0.1, 0.1, 0, 0, 0, 0, 0, 0)
                                sec_id = sec_id + 1
                            End If

                        ElseIf parts.Count = 3 Then
                            parsing_modifier(parts(1), parts(2))
                        Else
                            parsing_section(sec_id, parts(1), "Steel", "Steel", "Undefined", 0.1, 0.1, 0, 0, 0, 0, 0, 0)
                            sec_id = sec_id + 1
                        End If
                    End If

                    If parts(0) = "LOADPATTERN" Then
                        load_pattern.Checked = True
                        load_pattern.Enabled = True
                        parsing_loadpattern(loadpattern_id, parts(1), parts(3))
                        loadpattern_id = loadpattern_id + 1
                    End If

                    If parts(0) = "POINTLOAD" Then
                        point_loads.Checked = True
                        point_loads.Enabled = True
                        Dim lastnonempty As Integer = -1
                        For k As Integer = 0 To parts.Count - 1
                            If parts(k) <> "" Then
                                lastnonempty = lastnonempty + 1
                                parts(lastnonempty) = parts(k)
                            End If
                        Next
                        If lastnonempty < 0 Then
                            lastnonempty = 0
                        End If
                        ReDim Preserve parts(lastnonempty)
                        parsing_pointload(pointload_id, parts(1), parts(2), parts(6), parts(7))
                        pointload_id = pointload_id + 1
                    End If

                    If parts(0) = "LINELOAD" Then
                        line_loads.Checked = True
                        line_loads.Enabled = True
                        If lnas_chk = 0 Then
                            rearrange_elem()
                            lnas_chk = 1
                            ll_chk = 1
                        End If
                        Dim lastnonempty As Integer = -1
                        For k As Integer = 0 To parts.Count - 1
                            If parts(k) <> "" Then
                                lastnonempty = lastnonempty + 1
                                parts(lastnonempty) = parts(k)
                            End If
                        Next
                        If lastnonempty < 0 Then
                            lastnonempty = 0
                        End If
                        ReDim Preserve parts(lastnonempty)

                        If parts(4) = "POINTF" Then
                            Dim parts_brk() As String = parts(9).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            parsing_lineload(parts(1), parts(2), parts(8), parts(6), parts_brk(1), 0, parts_brk(3), 0, 0, 0, 0, 0, 0, 0, 0, 0, "CONLOAD")
                        End If
                        If parts(4) = "UNIFF" Then
                            Dim parts_brk() As String = parts(9).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                            parsing_lineload(parts(1), parts(2), parts(8), parts(6), parts_brk(1), parts_brk(1), 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, "UNILOAD")
                        End If
                        If parts(4) = "TRAPF" Then
                            Dim parts_brk() As String = parts(9).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

                            If parts(1) = prevpart Or lineload_ct = 0 Then
                                If lineload_ct = 0 Then
                                    p01 = parts_brk(1)
                                    p02 = parts_brk(3)
                                    p03 = parts_brk(5)
                                    p04 = parts_brk(7)
                                    prevpart = parts(1)
                                End If
                                If lineload_ct = 1 Then
                                    p11 = parts_brk(1)
                                    p12 = parts_brk(3)
                                    p13 = parts_brk(5)
                                    p14 = parts_brk(7)

                                End If
                                If lineload_ct = 2 Then
                                    p21 = parts_brk(1)
                                    p22 = parts_brk(3)
                                    p23 = parts_brk(5)
                                    p24 = parts_brk(7)

                                End If
                                lineload_ct = lineload_ct + 1
                            End If
                            If parts(1) <> prevpart And lineload_ct > 0 Then
                                If lineload_ct = 3 Then
                                    parsing_lineload(parts(1), parts(2), parts(8), parts(6), p01, p02, p03, p04, p11, p12, p13, p14, p21, p22, p23, p24, "UNILOAD")
                                    lineload_ct = 0
                                End If
                                If lineload_ct = 2 Then
                                    parsing_lineload(parts(1), parts(2), parts(8), parts(6), p01, p02, p03, p04, p11, p12, p13, p14, 0, 0, 0, 0, "UNILOAD")
                                    lineload_ct = 0
                                End If
                                If lineload_ct = 1 Then
                                    parsing_lineload(parts(1), parts(2), parts(8), parts(6), p01, p02, p03, p04, 0, 0, 0, 0, 0, 0, 0, 0, "UNILOAD")
                                    lineload_ct = 0
                                End If
                                prevpart = parts(1)
                                line_count = line_count - 1
                            End If
                        End If
                    End If

                    If parts(0) = "AREAASSIGN" Then
                        area_ass.Checked = True
                        area_ass.Enabled = True
                        Dim lastnonempty As Integer = -1
                        For k As Integer = 0 To parts.Count - 1
                            If parts(k) <> "" Then
                                lastnonempty = lastnonempty + 1
                                parts(lastnonempty) = parts(k)
                            End If
                        Next
                        If lastnonempty < 0 Then
                            lastnonempty = 0
                        End If
                        ReDim Preserve parts(lastnonempty)

                        parsing_areaassign(parts(1), parts(2), parts(4))
                    End If

                    If parts(0) = "AREA" Then
                        area_conn.Checked = True
                        area_conn.Enabled = True
                        Dim lastnonempty As Integer = -1
                        For k As Integer = 0 To parts.Count - 1
                            If parts(k) <> "" Then
                                lastnonempty = lastnonempty + 1
                                parts(lastnonempty) = parts(k)
                            End If
                        Next
                        If lastnonempty < 0 Then
                            lastnonempty = 0
                        End If
                        ReDim Preserve parts(lastnonempty)

                        Dim p_split() As String = parts(2).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        Dim nn As Integer = p_split(1)

                        For i_area = 0 To nn - 1
                            nodes.Add(parts(3 + i_area))
                        Next
                        Dim nodes_array As String() = nodes.ToArray()
                        If nodes_array.Count <= 4 Then
                            parsing_area_conn(parts(1), nodes_array, parts(3 + nn), 1) ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Else
                            ' Dim points() As PointF
                            Dim m_Points() As PointF = {}
                            Dim rn As Integer = 0
                            For j = 0 To nodes_array.Count - 1
                                rn = 0
                                For Each row As DataRow In dtcrtdnodeorg.Rows
                                    If nodes_array(j) = dtcrtdnodeorg.Rows(rn).Item("Node_Number_org") Then
                                        AddVertex(CSng(dtcrtdnodeorg.Rows(rn).Item("X1")), CSng(dtcrtdnodeorg.Rows(rn).Item("X2")), 0)
                                        ReDim Preserve m_Points(nodes_array.Count)
                                        m_Points(j) = New PointF(CSng(dtcrtdnodeorg.Rows(rn).Item("X1")), CSng(dtcrtdnodeorg.Rows(rn).Item("X2")))
                                    End If
                                    rn = rn + 1
                                Next
                            Next

                            Dim nodes_ind As New List(Of String)()
                            Dim node_string() As String = CalculateTriangles()
                            For k = 0 To node_string.Count - 1
                                Dim nodes_array_index() As String = node_string(k).Split(",")
                                Dim chk_inside As Integer = 1
                                If node_string.Count > nodes_array.Count - 2 Then
                                    chk_inside = 0
                                    Dim cgx As Single = 0
                                    Dim cgy As Single = 0
                                    Dim chk_1 As Integer = 0
                                    Dim chk_2 As Integer = 0
                                    Dim chk_3 As Integer = 0
                                    For lp_var = 0 To dtcrtdnodeorg.Rows.Count - 1
                                        If nodes_array(nodes_array_index(0)) = dtcrtdnodeorg.Rows(lp_var).Item("Node_Number_org") Then
                                            cgx = cgx + dtcrtdnodeorg.Rows(lp_var).Item("X1") / 3
                                            cgy = cgy + dtcrtdnodeorg.Rows(lp_var).Item("X2") / 3
                                            chk_1 = 1
                                        End If
                                        If nodes_array(nodes_array_index(1)) = dtcrtdnodeorg.Rows(lp_var).Item("Node_Number_org") Then
                                            cgx = cgx + dtcrtdnodeorg.Rows(lp_var).Item("X1") / 3
                                            cgy = cgy + dtcrtdnodeorg.Rows(lp_var).Item("X2") / 3
                                            chk_2 = 2
                                        End If
                                        If nodes_array(nodes_array_index(2)) = dtcrtdnodeorg.Rows(lp_var).Item("Node_Number_org") Then
                                            cgx = cgx + dtcrtdnodeorg.Rows(lp_var).Item("X1") / 3
                                            cgy = cgy + dtcrtdnodeorg.Rows(lp_var).Item("X2") / 3
                                            chk_3 = 3
                                        End If
                                        If chk_1 = 1 And chk_2 = 1 And chk_3 = 1 Then
                                            Exit For
                                        End If
                                    Next
                                    Dim return_chk As Boolean = PointInPolygon(m_Points, cgx, cgy)
                                    If return_chk = True Then
                                        chk_inside = 1
                                    Else
                                        chk_inside = 0
                                    End If
                                End If
                                If chk_inside = 1 Then
                                    For i_ind = 0 To 2
                                        nodes_ind.Add(nodes_array(nodes_array_index(i_ind)))
                                    Next
                                End If
                                Dim nodes_array_ind As String() = nodes_ind.ToArray()
                                Dim conc_check As Integer = 0
                                conc_check = straight_line_check(nodes_array_ind)
                                If conc_check = 1 Then
                                    parsing_area_conn(parts(1), nodes_array_ind, parts(3 + nn), 1)
                                End If

                                nodes_ind.Clear()
                            Next
                            EmptyVertexList()
                        End If
                        nodes.Clear()
                    End If

                    If parts(0) = "SHELLPROP" Then
                        thicknesses.Checked = True
                        thicknesses.Enabled = True
                        If parts.Count > 8 Then
                            If parts(3) = "Slab" Then
                                Dim th_parts() As String = parts(parts.Count - 1).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                parsing_thickness(thickness_id_slab, parts(1), parts(5), th_parts(1))
                                thickness_id_slab = thickness_id_slab + 1
                            End If
                            If parts(3) = "Wall" Then
                                Dim th_parts() As String = parts(parts.Count - 1).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                parsing_thickness(thickness_id_wall, parts(1), parts(5), th_parts(1))
                                thickness_id_wall = thickness_id_wall + 1
                            End If
                        End If
                    End If

                    'If line_count > 56700 Then
                    '    MessageBox.Show("BDIYHSB")
                    'End If

                    If parts(0) = "AREALOAD" Then
                        If parts(5) <> "TEMP" Then
                            area_loading.Checked = True
                            area_loading.Enabled = True
                            Dim lastnonempty As Integer = -1
                            For k As Integer = 0 To parts.Count - 1
                                If parts(k) <> "" Then
                                    lastnonempty = lastnonempty + 1
                                    parts(lastnonempty) = parts(k)
                                End If
                            Next
                            If lastnonempty < 0 Then
                                lastnonempty = 0
                            End If
                            ReDim Preserve parts(lastnonempty)
                            If parts.Count > 8 Then
                                Dim prt_brk() As String = parts(9).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                parsing_areaload(parts(1), parts(2), parts(4), parts(6), parts(8), prt_brk(1))
                            End If
                            If parts.Count = 6 And parts(4) = "UNIFLOADSET" Then
                                For i_ld = 0 To dt_loadset.Rows.Count - 1
                                    If dt_loadset.Rows(i_ld).Item("Loadset_name") = parts(5) Then
                                        parsing_areaload(parts(1), parts(2), "UNIFF", "GRAV", dt_loadset.Rows(i_ld).Item("Loadset_pattern"), dt_loadset.Rows(i_ld).Item("Loadset_magnitude"))
                                    End If

                                Next

                            End If

                        End If
                    End If

                    If parts(0) = "SHELLUNIFORMLOADSET" Then
                        unifloadset.Enabled = True
                        unifloadset.Checked = True
                        Dim lastnonempty As Integer = -1
                        For k As Integer = 0 To parts.Count - 1
                            If parts(k) <> "" Then
                                lastnonempty = lastnonempty + 1
                                parts(lastnonempty) = parts(k)
                            End If
                        Next
                        If lastnonempty < 0 Then
                            lastnonempty = 0
                        End If
                        ReDim Preserve parts(lastnonempty)
                        Dim parts_break() As String = parts(4).Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        parsing_loadset(parts(1), parts(3), parts_break(1))
                    End If

                    If parts(0) = "POINTSPRING" Then
                        constraints.Checked = True
                        constraints.Enabled = True
                        parsing_pointsprings(parts(1), parts(2))
                    End If

                End If
                line_count = line_count + 1
            End If
            Application.DoEvents()
        Next i_main_read

        out_path = in_path & "\" & only_file_name & ".mgt"

        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''JUST CHECKING''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'out_path_2 = in_path & "org.txt"
        'Using out_file_2 As New StreamWriter(out_path_2)
        '    For Each row As DataRow In dtarea_conn.Rows
        '        out_file_2.WriteLine(row("N1") & ", " & row("N2") & ", " & row("N3") & ", " & row("N4"))
        '    Next

        '    '    For Each row As DataRow In dtcrtdlineassign.Rows
        '    '        out_file_2.WriteLine(row("la_uq_elem") & ", " & row("la_story") & ", " & row("la_section"))
        '    '    Next

        '    '    For Each row As DataRow In dtStorydata.Rows
        '    '        out_file_2.WriteLine(row("la_uq_elem") & ", " & row("la_story") & ", " & row("la_section"))
        '    '    Next

        'End Using
        '    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''END CHECKING'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If ll_chk = 0 Then
            rearrange_elem()
            ll_chk = 1
        End If

        elem_section()
        area_element()

        If dtboundary_conditions.Rows.Count = 0 Then
            MessageBox.Show("Boundary Conditions Should be given by the User. Press OK to Continue file writting")
        End If
        ProgressBar_read.Value = ProgressBar_read.Maximum
        Using out_file As New StreamWriter(out_path)
            ProgressBar_writing.Minimum = 0
            ProgressBar_writing.Maximum = 10
            writing_units(out_file) '
            ProgressBar_writing.Value = 1 '
            Application.DoEvents() '
            writing_node(out_file) '
            ProgressBar_writing.Value = 2 '
            Application.DoEvents() '
            writing_elem(out_file) '
            ProgressBar_writing.Value = 3 '
            Application.DoEvents() '
            'writing_story(out_file)
            writing_BoundaryConditions(out_file)
            writting_spring(out_file)
            ProgressBar_writing.Value = 4
            Application.DoEvents()
            writing_material(out_file)
            ProgressBar_writing.Value = 5
            Application.DoEvents()
            writing_thickness(out_file)
            ProgressBar_writing.Value = 6
            Application.DoEvents()
            writing_section(out_file)
            ProgressBar_writing.Value = 7
            Application.DoEvents()
            writing_modifier(out_file)
            ProgressBar_writing.Value = 8
            Application.DoEvents()
            writing_loadpattern(out_file)
            ProgressBar_writing.Value = 9
            Application.DoEvents()
            writing_load(out_file)
            ProgressBar_writing.Value = 10
            Application.DoEvents()
            'writing_floadtype(out_file)
            ' areaload_floorload()
            'writing_floorload(out_file)
            MessageBox.Show("Writting Completed." & vbNewLine & "Location :  " & CStr(out_path))

            Process.Start(out_path)
        End Using
        delete_db()
        delete_db_SAFE()
    End Function
    Function SCRAPE_DATA_SAFE()
        ''' SCRAPEING DATA OF F2K SAFE FILE  '''

        Dim words() As String = lines  ''remove and keep direct lines
        Dim temp As String = ""
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''
        For a = 0 To words.Length - 1
            '''
            ProgressBar_read.Value = a
            '''''
            If words(a).Contains("""PROGRAM CONTROL""") Then
                temp = words(a).Remove(2, ("""PROGRAM CONTROL""").Length)
                Dim r As MatchCollection = Regex.Matches(temp, "(?<=CurrUnits="").*(?=""\s+MergeTol)")
                Dim words1() As String = r(0).ToString().Split(New Char() {","c})
                If words1(0) = "LB" Or words1(0) = "lb" Then
                    words1(0) = "LBF"
                End If
                dtPCunits_read.Rows.Add(words1(0), words1(1), "BTU", words1(2))
                units.Checked = True : units.Enabled = True


            ElseIf words(a).Contains("""OBJECT GEOMETRY - POINT COORDINATES""") Then
                temp = words(a).Remove(2, ("""OBJECT GEOMETRY - POINT COORDINATES""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.+-_*]+)")
                For b = 0 To mc.Count - 1 Step 5
                    dtOGPC_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4))
                    points.Checked = True : points.Enabled = True
                Next

            ElseIf words(a).Contains("""OBJECT GEOMETRY - LINES 01 - GENERAL""") Then
                temp = words(a).Remove(2, ("""OBJECT GEOMETRY - LINES 01 - GENERAL""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<=Line=|PointI=|PointJ=|LineType=)[\w\.+-_]+)")
                For b = 0 To mc.Count - 1 Step 4
                    dtOGL_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), "NOTREQUIRED", "NOTREQUIRED")
                Next
                element_conn.Checked = True : element_conn.Enabled = True

            ElseIf words(a).Contains("""OBJECT GEOMETRY - AREAS 01 - GENERAL""") Then
                temp = words(a).Remove(2, ("""OBJECT GEOMETRY - AREAS 01 - GENERAL""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)\w*\.?\w*)")
                Dim b As Integer = 0
                While b < mc.Count - 1
                    If Convert.ToString(mc(b + 1)) = "4" And Convert.ToString(mc(b + 8)) = "Wall" Then
                        If Convert.ToDouble(Convert.ToString(mc(b + 7))) > 0 Then
                            dtOGA_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), _
                    mc(b + 5), mc(b + 6), mc(b + 7), mc(b + 8), "NIL")
                            b = b + 9
                        Else
                            b = b + 9
                        End If
                    ElseIf Convert.ToString(mc(b + 1)) = "4" And Convert.ToString(mc(b + 8)) = "Slab" Then  ' Initial b =0

                        If Convert.ToDouble(Convert.ToString(mc(b + 7))) > 0 Then
                            dtOGA_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), _
                                          mc(b + 5), mc(b + 6), mc(b + 7), mc(b + 8), mc(b + 9))
                            b = b + 10
                        Else
                            b = b + 10
                        End If
                    ElseIf Convert.ToString(mc(b + 1)) = "3" And Convert.ToString(mc(b + 7)) = "Slab" Then  ' Initial b =0
                        dtOGA_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), _
                                            "NIL", mc(b + 5), mc(b + 6), mc(b + 7), mc(b + 8))
                        b = b + 9
                    ElseIf CInt(Convert.ToString(mc(b + 1))) > 4 And Convert.ToString(mc(b + 8)) = "Slab" Then  ' Initial b =0 ' add waffel and others
                        'Else
                        dtOGA_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), _
                                           mc(b + 5), mc(b + 6), mc(b + 7), mc(b + 8), mc(b + 9))
                        Dim temp2 As Integer 'store previous b valuein >4
                        Dim temp1 As Integer ' 4 or 3 or2 element in line
                        Dim NumPoints As Integer = CInt(Convert.ToString(mc(b + 1)))
                        Dim AreaType As String = Convert.ToString(mc(b + 8))

                        temp2 = b
                        temp1 = CInt(Convert.ToString(mc(b + 1))) - 4  'Reducing four pointes for each step ' If temp1 zero terminates
                        b = b + 10

                        While Convert.ToString(mc(b)) = Convert.ToString(mc(temp2))

                            If temp1 >= 4 Then
                                dtOGA_read.Rows.Add(mc(b), NumPoints, mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), _
                                           "NIL", "NIL", AreaType, "NIL")
                                b = b + 5 : temp1 = temp1 - 4
                                If temp1 = 0 Then  ' if not error in end of line
                                    Exit While
                                End If
                            ElseIf temp1 = 3 Then
                                dtOGA_read.Rows.Add(mc(b), NumPoints, mc(b + 1), mc(b + 2), mc(b + 3), "NIL", _
                                           "NIL", "NIL", AreaType, "NIL")
                                b = b + 4 : temp1 = temp1 - 3
                                If temp1 = 0 Then  ' if not error in end of line
                                    Exit While
                                End If
                            ElseIf temp1 = 2 Then
                                dtOGA_read.Rows.Add(mc(b), NumPoints, mc(b + 1), mc(b + 2), "NIL", "NIL", _
                                                     "NIL", "NIL", AreaType, "NIL")
                                b = b + 3 : temp1 = temp1 - 2
                                If temp1 = 0 Then  ' if not error in end of line
                                    Exit While
                                End If
                            ElseIf temp1 = 1 Then
                                dtOGA_read.Rows.Add(mc(b), NumPoints, mc(b + 1), "NIL", "NIL", "NIL", _
                                                     "NIL", "NIL", AreaType, "NIL")
                                b = b + 2 : temp1 = temp1 - 1
                                If temp1 = 0 Then  ' if not error in end of line
                                    Exit While
                                End If
                            End If
                        End While
                    End If
                End While
                area_conn.Checked = True : area_conn.Enabled = True
                area_ass.Checked = True : area_ass.Enabled = True


                '''''''''''''''''''''''''''''''''''''''''''''''''''  NOTREQUIRED
                'ElseIf words(a).Contains("""OBJECT GEOMETRY - DESIGN STRIPS""") Then
                '    temp = words(a).Remove(2, ("""OBJECT GEOMETRY - DESIGN STRIPS""").Length)
                '    Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)\w*\.?\w*)")
                '    For b = 0 To mc.Count - 1 Step 6
                '        dtOGDS_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5))
                '    Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""MATERIAL PROPERTIES 01 - GENERAL""") Then
                temp = words(a).Remove(2, ("""MATERIAL PROPERTIES 01 - GENERAL""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "(((?<==)\w*\.?\w*)(?=\s\s))|("".*"")|(((?<==)[\w\.+-]+))")
                For b = 0 To mc.Count - 1 Step 4
                    dtMPG_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""MATERIAL PROPERTIES 03 - CONCRETE""") Then
                temp = words(a).Remove(2, ("""MATERIAL PROPERTIES 03 - CONCRETE""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<=Material=|E=|U=|A=|UnitWt=|Fc=)[\w\.+-]+)")
                Dim b As Integer = 0
                For b = 0 To mc.Count - 1 Step 6
                    dtMPC_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), "NOTREQUIRED")
                    material.Checked = True : material.Enabled = True
                Next

            ElseIf words(a).Contains("""MATERIAL PROPERTIES 02 - STEEL""") Then
                temp = words(a).Remove(2, ("""MATERIAL PROPERTIES 02 - STEEL""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.+-]+)")
                For b = 0 To mc.Count - 1 Step 7
                    dtMPS_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6))
                    material.Checked = True : material.Enabled = True
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""MATERIAL PROPERTIES 04 - REBAR""") Then
                temp = words(a).Remove(2, ("""MATERIAL PROPERTIES 04 - REBAR""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.+-]+)")
                For b = 0 To mc.Count - 1 Step 5
                    dtMPR_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4))
                    material.Checked = True : material.Enabled = True
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""MATERIAL PROPERTIES 05 - TENDON""") Then
                temp = words(a).Remove(2, ("""MATERIAL PROPERTIES 05 - TENDON""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.+-]+)")
                For b = 0 To mc.Count - 1 Step 5
                    dtMPT_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4))
                    material.Checked = True : material.Enabled = True
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""MATERIAL PROPERTIES 06 - OTHER""") Then
                temp = words(a).Remove(2, ("""MATERIAL PROPERTIES 06 - OTHER""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.+-]+)")
                For b = 0 To mc.Count - 1 Step 5
                    dtMPO_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''  NOTREQUIRED
                'ElseIf words(a).Contains("""SLAB PROPERTIES 01 - GENERAL""") Then
                '    temp = words(a).Remove(2, ("""SLAB PROPERTIES 01 - GENERAL""").Length)
                '    Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.+-]+)")
                '    For b = 0 To mc.Count - 1 Step 3
                '        dtSPG_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2))
                '    Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""SLAB PROPERTIES 02 - SOLID SLABS""") Then
                temp = words(a).Remove(2, ("""SLAB PROPERTIES 02 - SOLID SLABS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.+-]+)")
                For b = 0 To mc.Count - 1 Step 5
                    dtSPSS_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4))
                Next
                thicknesses.Checked = True : thicknesses.Enabled = True


                '''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""SLAB PROPERTIES 03 - RIBBED AND WAFFLE SLABS""") Then
                temp = words(a).Remove(2, ("""SLAB PROPERTIES 02 - SOLID SLABS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<=Slab=|Type=|MatProp=|TotalDepth=|SlabThick=)[\w\.+-]+)") ' OTHER PAREAMETER THERE IF REQUIRE ADD IT
                For b = 0 To mc.Count - 1 Step 5
                    dtSPRW_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf words(a).Contains("""SOIL PROPERTIES""") Then
                temp = words(a).Remove(2, ("""SOIL PROPERTIES""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.+-]+)")
                For b = 0 To mc.Count - 1 Step 3
                    dtSP_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""SPRING PROPERTIES - LINE""") Then
                temp = words(a).Remove(2, ("""SPRING PROPERTIES - LINE""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 6
                    dtSPL_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), "Notes:ifwantupdate")
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""SPRING PROPERTIES - POINT""") Then
                temp = words(a).Remove(2, ("""SPRING PROPERTIES - POINT""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<=Spring=|Ux=|Uy=|Uz=|Rx=|Ry=|Rz=)[\w\._+-.\b]+)")
                Dim b As Integer = 0
                For b = 0 To mc.Count - 1 Step 7
                    dtSPP_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6), "NOTREQUIRED", "NOTREQUIRED")
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''  NOREQUIRED
                'If words(a).Contains("""BEAM PROPERTIES 01 - GENERAL""") Then
                '    temp = words(a).Remove(2, ("""BEAM PROPERTIES 01 - GENERAL""").Length)
                '    Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")") 'nO REGEX FOR NOTE IF WANT ADD IT  '"((?<==)[\w\._+-.]+)|("".*"")"
                '    For b = 0 To mc.Count - 1 Step 3

                '        dtBPG_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), "NOTES_NOT_IMPOTANT")
                '    Next
                '    sections.Checked = True
                '    sections.Enabled = True
                'End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""BEAM PROPERTIES 02 - RECTANGULAR BEAM""") Then
                temp = words(a).Remove(2, ("""BEAM PROPERTIES 02 - RECTANGULAR BEAM""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")") '((?<==)[\w\._+-.]+)|(?<=Beam=)(".*")(?=\s\s++MatProp)
                For b = 0 To mc.Count - 1 Step 5
                    dtBPRB_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4))
                Next
                sections.Checked = True : sections.Enabled = True


                ''''''''''''''''''''''''''''''''''''''''''''''''''' NOTREQUIRED
                'ElseIf words(a).Contains("""COLUMN PROPERTIES 01 - GENERAL""") Then
                '    temp = words(a).Remove(2, ("""COLUMN PROPERTIES 01 - GENERAL""").Length)
                '    Dim mc As MatchCollection = Regex.Matches(temp, "(?<=Column=|MatProp=|SecDim2=|SecDim3=)(.?\w+){0,}""?") '(?<==)(.\w+.\w+.\w.)|(?<==)(.\w+.\w+.)|(?<==)([\w\.]+)  ' "((?<=Column=|Type=|Color=)[\w\._+-.]+)|("".*"")"
                '    For b = 0 To mc.Count - 1 Step 3
                '        dtCPG_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), "NOTREQUIRED")
                '    Next


                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""COLUMN PROPERTIES 02 - RECTANGULAR""") Then
                temp = words(a).Remove(2, ("""COLUMN PROPERTIES 02 - RECTANGULAR""").Length) '(?<==)(.?\w+){1,}"?
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<=Column=|MatProp=|SecDim2=|SecDim3=)[\w\._+-.]+)") '"((?<==)[\w\._+-.]+)|("".*"")"
                For b = 0 To mc.Count - 1 Step 4
                    dtCPR_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), "NOREQUIRED", "NOREQUIRED", "NOREQUIRED", "NOREQUIRED", "NOREQUIRED", "NOREQUIRED")
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""WALL PROPERTIES""") Then
                temp = words(a).Remove(2, ("""WALL PROPERTIES""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<=Wall=|MatProp=|Thickness=)[\w\._+-.]+)") '((?<==)[\w\._+-.]+)|("".*"")
                For b = 0 To mc.Count - 1 Step 3
                    dtWP_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), "NOREQUIRED", "NOREQUIRED", "NOREQUIRED", "NOREQUIRED")
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""LOAD PATTERNS""") Then
                temp = words(a).Remove(2, ("""LOAD PATTERNS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 3
                    dtLP_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""LOAD CASES 01 - GENERAL""") Then
                temp = words(a).Remove(2, ("""LOAD CASES 01 - GENERAL""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 4
                    dtLCG_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""LOAD CASES 02 - STATIC""") Then
                temp = words(a).Remove(2, ("""LOAD CASES 02 - STATIC""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 3
                    dtLCS_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2))
                Next

                ''''''''''''''''''''''''''''''''''''''''''''''''''' NOTREQUIRED
                'If words(a).Contains("""LOAD CASES 06 - LOADS APPLIED""") Then
                '    temp = words(a).Remove(2, ("""LOAD CASES 06 - LOADS APPLIED""").Length)
                '    Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                '    For b = 0 To mc.Count - 1 Step 3
                '        dtLCLA_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2))
                '    Next
                'End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''     NOTREQUIRED       
                'If words(a).Contains("""LOAD COMBINATIONS""") Then
                '    temp = words(a).Remove(2, ("""LOAD COMBINATIONS""").Length)
                '    Dim mc As MatchCollection = Regex.Matches(temp, "((?<=Combo=|Load=|SF=)[\w\._+-.]+)")
                '    For b = 0 To mc.Count - 1 Step 3
                '        dtLC_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), "NOREQUIRED", "NOREQUIRED", "NOREQUIRED", "NOREQUIRED", "NOREQUIRED", "NOREQUIRED")
                '    Next
                'End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''       
            ElseIf words(a).Contains("""LOAD ASSIGNMENTS - POINT LOADS""") Then
                temp = words(a).Remove(2, ("""LOAD ASSIGNMENTS - POINT LOADS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\.\-_+.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 10
                    dtLAPL_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6), mc(b + 7), mc(b + 8), mc(b + 9))
                Next
                point_loads.Checked = True : point_loads.Enabled = True

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""SLAB PROPERTY ASSIGNMENTS""") Then
                temp = words(a).Remove(2, ("""SLAB PROPERTY ASSIGNMENTS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<=Area=|SlabProp=)[\w\.+-]+)")
                For b = 0 To mc.Count - 1 Step 2 ' 3 or 2 ??
                    dtSPA_read.Rows.Add(mc(b), mc(b + 1), "NOTREQUIRED")
                Next
                area_loading.Checked = True : area_loading.Enabled = True

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""BEAM PROPERTY ASSIGNMENTS""") Then
                temp = words(a).Remove(2, ("""BEAM PROPERTY ASSIGNMENTS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 2
                    dtBPA_read.Rows.Add(mc(b), mc(b + 1))
                Next
                section_assignment.Checked = True : section_assignment.Enabled = True

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""BEAM INSERTION POINT""") Then
                temp = words(a).Remove(2, ("""BEAM INSERTION POINT""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 8
                    dtBIP_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6), mc(b + 7))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""COLUMN PROPERTY ASSIGNMENTS""") Then
                temp = words(a).Remove(2, ("""COLUMN PROPERTY ASSIGNMENTS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 2
                    dtCPA_read.Rows.Add(mc(b), mc(b + 1))
                Next

            ElseIf words(a).Contains("""COLUMN LOCAL AXES""") Then
                temp = words(a).Remove(2, ("""COLUMN LOCAL AXES""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 2
                    dtCLA_read.Rows.Add(mc(b), mc(b + 1))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""COLUMN INSERTION POINT""") Then
                temp = words(a).Remove(2, ("""COLUMN INSERTION POINT""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 8
                    dtCIP_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6), mc(b + 7))

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""WALL PROPERTY ASSIGNMENTS""") Then
                temp = words(a).Remove(2, ("""WALL PROPERTY ASSIGNMENTS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 2
                    dtWPA_read.Rows.Add(mc(b), mc(b + 1))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf words(a).Contains("""POINT RESTRAINT ASSIGNMENTS""") Then
                temp = words(a).Remove(2, ("""POINT RESTRAINT ASSIGNMENTS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 7
                    dtPRA_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6))
                Next
                constraints.Checked = True : constraints.Enabled = True

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""POINT SPRING ASSIGNMENTS""") Then
                temp = words(a).Remove(2, ("""POINT SPRING ASSIGNMENTS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 2
                    dtPSA_read.Rows.Add(mc(b), mc(b + 1))
                Next
                POINT_SPRING.Checked = True : POINT_SPRING.Enabled = True

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""LOAD ASSIGNMENTS - SURFACE LOADS""") Then
                temp = words(a).Remove(2, ("""LOAD ASSIGNMENTS - SURFACE LOADS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 7
                    dtLASL_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6))

                Next
                area_loading.Checked = True : area_loading.Enabled = True
                unifloadset.Enabled = True : unifloadset.Checked = True




                '''''''''''''''''''''''''''''''''''''''''''''''''''       
            ElseIf words(a).Contains("""COLUMN PROPERTIES 03 - CIRCULAR""") Then
                temp = words(a).Remove(2, ("""COLUMN PROPERTIES 03 - CIRCULAR""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 6
                    dtCPC_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5))
                Next


                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""BEAM PROPERTIES 03 - T BEAM""") Then
                temp = words(a).Remove(2, ("""BEAM PROPERTIES 03 - T BEAM""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 8
                    dtBPTB_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6), mc(b + 7))
                Next
                material.Checked = True : material.Enabled = True

                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""COLUMN PROPERTIES 04 - T SHAPE""") Then
                temp = words(a).Remove(2, ("""COLUMN PROPERTIES 04 - T SHAPE""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 8
                    dtCPTS_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""BEAM PROPERTIES 04 - L BEAM""") Then
                temp = words(a).Remove(2, ("""BEAM PROPERTIES 04 - L BEAM""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 8
                    dtBPLB_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6), mc(b + 7))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""COLUMN PROPERTIES 05 - L SHAPE""") Then
                temp = words(a).Remove(2, ("""COLUMN PROPERTIES 05 - L SHAPE""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 8
                    dtCPLS_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""SOIL PROPERTY ASSIGNMENTS""") Then
                temp = words(a).Remove(2, ("""SOIL PROPERTY ASSIGNMENTS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 2
                    dtSoilA_read.Rows.Add(mc(b), mc(b + 1))
                    SURFACE_SPRING.Checked = True : SURFACE_SPRING.Enabled = True
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''
                ' dtLSA_read.
            ElseIf words(a).Contains("""LINE SPRING ASSIGNMENTS""") Then
                temp = words(a).Remove(2, ("""LINE SPRING ASSIGNMENTS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 2
                    dtLSA_read.Rows.Add(mc(b), mc(b + 1))
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""LOAD ASSIGNMENTS - LINE OBJECTS - DISTRIBUTED LOADS""") Then
                temp = words(a).Remove(2, ("""LOAD ASSIGNMENTS - LINE OBJECTS - DISTRIBUTED LOADS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "((?<==)[\w\._+-.""]+)|("".*"")")
                For b = 0 To mc.Count - 1 Step 11
                    dtLALDL_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6), mc(b + 7), mc(b + 8), mc(b + 9), mc(b + 10))

                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf words(a).Contains("""LOAD ASSIGNMENTS - POINT DISPLACEMENT LOADS""") Then
                temp = words(a).Remove(2, ("""LOAD ASSIGNMENTS - POINT DISPLACEMENT LOADS""").Length)
                Dim mc As MatchCollection = Regex.Matches(temp, "(?<==)(.?\w+){0,}""?") ' Best regex
                For b = 0 To mc.Count - 1 Step 8
                    dtLAPD_read.Rows.Add(mc(b), mc(b + 1), mc(b + 2), mc(b + 3), mc(b + 4), mc(b + 5), mc(b + 6), mc(b + 7))
                Next

            End If
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Function
    Function ARRANGE_DATA_SAFE()
        'ProgressBar
        ProgressBar_read.Value = lines.Length() + (lines.Length() / 100) * 2
        '''''
        'ARRANG_DATA_SAFE
        'NODES
        For Each row As DataRow In dtOGPC_read.Rows
            dtNODE_arrange.Rows.Add(row(0), row(1), row(2), row(3))
        Next

        'NODAL LOADS
        For Each row As DataRow In dtLAPL_read.Rows
            dtNODELOAD_arrange.Rows.Add(row(0), row(2), row(3), -1 * Convert.ToDouble(Convert.ToString(row(4))), row(5), row(6), row(7), row(1))
        Next

        'LINE LOAD'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For Each row As DataRow In dtLALDL_read.Rows
            If row("Dir") = """Global X""" Then
                row("Dir") = "GX"
            ElseIf Convert.ToString(row("Dir")) = """Global Y""" Then
                row("Dir") = "GY"
            ElseIf Convert.ToString(row("Dir")) = "Gravity" Then
                row("Dir") = "GZ"
                row("FOverLA") = -1 * Convert.ToDouble(Convert.ToString(row("FOverLA")))
                row("FOverLB") = -1 * Convert.ToDouble(Convert.ToString(row("FOverLB")))
            ElseIf Convert.ToString(row("Dir")) = """Local 1""" Then
                row("Dir") = "LX"
            ElseIf Convert.ToString(row("Dir")) = """Local 2""" Then
                row("Dir") = "LY"
            ElseIf Convert.ToString(row("Dir")) = """Local 3""" Then
                row("Dir") = "LZ"
            Else  ' Not to have error
                row("Dir") = "GZ" ' Print msg box ' 
            End If
            ''''''''''''''''''''''''''''''
            If Convert.ToString(row("Type")) = "Force" Then
                dtBEAMLOAD_arrange.Rows.Add(row("Line"), "LINE", "UNILOAD", row("Dir"), "YES, NO, aDir[1], , , ,", row("RelDistA"), row("FOverLA"), row("RelDistB"), row("FOverLB"), " 0, 0, 0, 0, , NO, 0, 0, NO, ", row("LoadPat"))
            ElseIf Convert.ToString(row("Type")) = "Moment" Then
                dtBEAMLOAD_arrange.Rows.Add(row("Line"), "LINE", "UNIMOMENT", row("Dir"), "YES, NO, aDir[1], , , ,", row("RelDistA"), row("FOverLA"), row("RelDistB"), row("FOverLB"), " 0, 0, 0, 0, , NO, 0, 0, NO, ", row("LoadPat"))
            Else 'To avoide error default 'Message box
                dtBEAMLOAD_arrange.Rows.Add(row("Line"), "LINE", "UNILOAD", row("Dir"), "YES, NO, aDir[1], , , ,", row("RelDistA"), row("FOverLA"), row("RelDistB"), row("FOverLB"), " 0, 0, 0, 0, , NO, 0, 0, NO, ", row("LoadPat"))
            End If
            line_loads.Checked = True : line_loads.Enabled = True
        Next

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'NODALDISPLACEMENT dtPOINTDISPLOAD_arrange
        For Each row As DataRow In dtLAPD_read.Rows
            row("Ugrav") = -1 * Convert.ToDouble(Convert.ToString(row("Ugrav")))
            dtPOINTDISPLOAD_arrange.Rows.Add(row(0), "111111", row("Ux"), row("Ux"), row("Ugrav"), row("Rx"), row("Ry"), row("Rz"), row("LoadPat")) 'row("LoadPat") dead or live
            point_disp_load.Checked = True : point_disp_load.Enabled = True
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Material  
        Dim no_count As Integer = 1
        'FOR NO PROPERTY DEFINE EXEPTIONAL
        dtMATERIAL_arrange.Rows.Add(no_count, "CONC", "MAT_DEF*", "0", "0", " ", "C", "NO", "0.05", "2", "28200000", "0.2", "0.00000989999989542412", "25", "0")
        no_count = no_count + 1
        'Concrete
        For Each row As DataRow In dtMPC_read.Rows
            dtMATERIAL_arrange.Rows.Add(no_count, "CONC", row(0), "0", "0", " ", "C", "NO", "0.05", "2", row(1), row(2), row(3), row(4), "0")
            no_count = no_count + 1
        Next
        'REBAR" 2
        For Each row As DataRow In dtMPR_read.Rows
            dtMATERIAL_arrange.Rows.Add(no_count, "STEEL", row(0), "0", "0", " ", "C", "NO", "0.05", "2", row(1), "0.3", "0", row(2), "0")
            no_count = no_count + 1
        Next
        '''steel    3
        For Each row As DataRow In dtMPS_read.Rows
            dtMATERIAL_arrange.Rows.Add(no_count, "STEEL", row(0), "0", "0", " ", "C", "NO", "0.05", "2", row(1), row(2), row(3), row(4), "0")
            no_count = no_count + 1
        Next
        ''' OTHER   4
        For Each row As DataRow In dtMPO_read.Rows
            dtMATERIAL_arrange.Rows.Add(no_count, "USER", row(0), "0", "0", " ", "C", "NO", "0.05", "2", row(1), row(2), row(3), row(4), "0")
            no_count = no_count + 1
        Next
        ' Tendon    5
        For Each row As DataRow In dtMPT_read.Rows
            dtMATERIAL_arrange.Rows.Add(no_count, "USER", row(0), "0", "0", " ", "C", "NO", "0.05", "2", row(1), "0.3", "0", row(2), "0")
            no_count = no_count + 1
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'ProgressBar
        ProgressBar_read.Value = lines.Length() + (lines.Length() / 100) * 3
        '''''
        'SECTIONS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        no_count = 1
        'FOR NO PROPERTY DEFINE EXEPTIONAL
        dtSECTION_arrange.Rows.Add(no_count, "DBUSER", "SEC_DEF*", "CC, 0, 0, 0, 0, 0, 0, YES, NO", "SB", "2", "0.1", "0.1", "0", "0", "0", "0", "0", "0", "0", "0")
        no_count = no_count + 1
        'BEAM
        For Each row As DataRow In dtBPRB_read.Rows
            dtSECTION_arrange.Rows.Add(no_count, "DBUSER", row(0), "CC, 0, 0, 0, 0, 0, 0, YES, NO", "SB", "2", row(2), row(3), "0", "0", "0", "0", "0", "0", "0", "0")
            no_count = no_count + 1
        Next
        'T_BEAM
        For Each row As DataRow In dtBPTB_read.Rows
            dtSECTION_arrange.Rows.Add(no_count, "DBUSER", row(0), "CC, 0, 0, 0, 0, 0, 0, YES, NO", "T", "2", row(2), row(4), row(5), row(3), "0", "0", "0", "0", "0", "0")
            no_count = no_count + 1
        Next
        'L_BEAM
        For Each row As DataRow In dtBPLB_read.Rows
            dtSECTION_arrange.Rows.Add(no_count, "DBUSER", row(0), "CC, 0, 0, 0, 0, 0, 0, YES, NO", "L", "2", row(2), row(4), row(5), row(3), "0", "0", "0", "0", "0", "0")
            no_count = no_count + 1
        Next
        'COLUMN
        For Each row As DataRow In dtCPR_read.Rows
            dtSECTION_arrange.Rows.Add(no_count, "DBUSER", row(0), "CC, 0, 0, 0, 0, 0, 0, YES, NO", "SB", "2", row(2), row(3), "0", "0", "0", "0", "0", "0", "0", "0")
            no_count = no_count + 1
        Next
        'COLUMN T 
        For Each row As DataRow In dtCPTS_read.Rows
            dtSECTION_arrange.Rows.Add(no_count, "DBUSER", row(0), "CC, 0, 0, 0, 0, 0, 0, YES, NO", "T", "2", row(3), row(2), row(4), row(5), "0", "0", "0", "0", "0", "0")
            no_count = no_count + 1
        Next
        'COLUMN L 
        For Each row As DataRow In dtCPLS_read.Rows
            dtSECTION_arrange.Rows.Add(no_count, "DBUSER", row(0), "CC, 0, 0, 0, 0, 0, 0, YES, NO", "L", "2", row(3), row(2), row(4), row(5), "0", "0", "0", "0", "0", "0")
            no_count = no_count + 1
        Next
        'CIRCULOR COLUMN
        For Each row As DataRow In dtCPC_read.Rows
            dtSECTION_arrange.Rows.Add(no_count, "DBUSER", row(0), "CC, 0, 0, 0, 0, 0, 0, YES, NO", "SR", "2", row(2), "0", "0", "0", "0", "0", "0", "0", "0", "0")
            no_count = no_count + 1
        Next

        'ProgressBar
        ProgressBar_read.Value = lines.Length() + (lines.Length() / 100) * 4
        '''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'thickness 'SLAB        1
        no_count = 1
        'FOR NO PROPERTY DEFINE EXEPTIONAL
        dtTHICKNESS_arrange.Rows.Add(no_count, "VALUE", "YES", 0.1, "0, NO", "0", "0", "None")
        no_count = no_count + 1
        'DROP
        For Each row As DataRow In dtSPSS_read.Rows
            If Convert.ToString(row(1)) = "Drop" Then
                dtTHICKNESS_arrange.Rows.Add(no_count, "VALUE", "YES", row(3), "0, YES", "0", "-0.5", row(0))
                no_count = no_count + 1
            Else
                dtTHICKNESS_arrange.Rows.Add(no_count, "VALUE", "YES", row(3), "0, NO", "0", "0", row(0))
                no_count = no_count + 1
            End If
        Next
        'Thickness ribbed and waffle slabs      2
        For Each row As DataRow In dtSPRW_read.Rows
            dtTHICKNESS_arrange.Rows.Add(no_count, "VALUE", "YES", row("SlabThick"), "0, YES", "0", "0", row(0))
            no_count = no_count + 1
        Next
        'thickness 'WALL        3
        For Each row As DataRow In dtWP_read.Rows
            dtTHICKNESS_arrange.Rows.Add(no_count, "VALUE", "YES", row(2), "0,  NO", "0", "0", row(0))
            no_count = no_count + 1
        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'ProgressBar
        ProgressBar_read.Value = lines.Length() + (lines.Length() / 100) * 5
        '''''

        'Point spring
        For Each row As DataRow In dtPSA_read.Rows
            no_count = 0
            For Each row2 As DataRow In dtSPP_read.Rows
                If Convert.ToString(row(1)) = Convert.ToString(row2(0)) Then
                    dtSPRINGPOINT_arrange.Rows.Add(row(0), "LINEAR", row2("Ux"), row2("Uy"), row2("Uz"), row2("Rx"), row2("Ry"), row2("Rz"), "NO, 0, 0, 0, 0, 0, 0, , 0, 0, 0, 0, 0")
                    no_count = no_count + 1
                End If
            Next

        Next

        'CONSTRAIN
        For Each row As DataRow In dtPRA_read.Rows
            For a = 1 To 6
                If Convert.ToString(row(a)) = "Yes" Then
                    row(a) = 1
                Else
                    row(a) = 0
                End If
            Next
            dtCONSTRAIN_arrange.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6))
            no_count = no_count + 1
        Next

        '*PRESSURE 'SURFACELOAD 
        For Each row As DataRow In dtLASL_read.Rows
            If Convert.ToString(row(2)) = """Global X""" Then
                row(2) = "GX"
            ElseIf Convert.ToString(row(2)) = """Global Y""" Then
                row(2) = "GY"
            ElseIf Convert.ToString(row(2)) = "Gravity" Then
                row(2) = "GZ"
                row(3) = -1 * Convert.ToDouble(Convert.ToString(row(3)))
            ElseIf Convert.ToString(row(2)) = """Local 1""" Then
                row(2) = "LX"
            ElseIf Convert.ToString(row(2)) = """Local 2""" Then
                row(2) = "LY"
            ElseIf Convert.ToString(row(2)) = """Local 3""" Then
                row(2) = "LZ"
            Else  ' Not to have error  Print msg box ' over all one note
                row(2) = "GZ" '
            End If
            dtPRESSURE_arrange.Rows.Add(row(0), "PRES", "PLATE", "FACE", row(2), "0, 0, 0", "NO", row(3), "0, 0, 0, 0,", row(1))
        Next

        'ProgressBar
        ProgressBar_read.Value = lines.Length() + (lines.Length() / 100) * 6
        '''''

        'LOAD CASES     "LOAD PATTERNS"
        For Each row As DataRow In dtLP_read.Rows
            If Convert.ToString(row(1)) = "DEAD" Then
                row(1) = "D" 'DEAD
            ElseIf Convert.ToString(row(1)) = "LIVE" Then
                row(1) = "L" 'LIVE
            ElseIf Convert.ToString(row(1)) = "QUAKE" Then
                row(1) = "E" 'LIVE
            ElseIf Convert.ToString(row(1)) = "WIND" Then
                row(1) = "W" 'LIVE
            Else
                row(1) = "USER" 'OTHER
            End If
            dtSTLDCASE_arrange.Rows.Add(row(0), row(1), "WriteOwnDescription")
            load_pattern.Checked = True
            load_pattern.Enabled = True
        Next

        'ELEMENTS''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'BEAM 
        For Each row As DataRow In dtOGL_read.Rows
            dtBEAM_arrange.Rows.Add(row(0), "BEAM", "material", row(3), row(1), row(2), "0", "0", row(0))
        Next

        no_count = 0
        For Each row As DataRow In dtOGL_read.Rows
            'COLUMN
            For Each row2 As DataRow In dtCPA_read.Rows
                If row(0) = row2(0) And Convert.ToString(row(3)) = "Column" Then
                    dtBEAM_arrange.Rows(no_count).Item("iPRO") = row2(1)
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1) '''''
                End If
            Next
            'Beam
            For Each row2 As DataRow In dtBPA_read.Rows
                If row(0) = row2(0) And Convert.ToString(row(3)) = "Beam" Then
                    dtBEAM_arrange.Rows(no_count).Item("iPRO") = row2(1)
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1) '''''
                End If
            Next
            no_count = no_count + 1
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        no_count = 0
        For Each row As DataRow In dtBEAM_arrange.Rows
            'COLUMN
            For Each row2 As DataRow In dtCPR_read.Rows
                If row(3) = row2(0) Then
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next
            'COLUMN CIRCULAR
            For Each row2 As DataRow In dtCPC_read.Rows
                If row(3) = row2(0) Then
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next
            'COLUMN T SHAPE  
            For Each row2 As DataRow In dtCPTS_read.Rows
                If row(3) = row2(0) Then
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next
            'COLUMN L SHAPE   
            For Each row2 As DataRow In dtCPLS_read.Rows
                If row(3) = row2(0) Then
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next
            'BEAM  ' Rectangular 
            For Each row2 As DataRow In dtBPRB_read.Rows
                If row(3) = row2(0) Then
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next
            'BEAM  'T   
            For Each row2 As DataRow In dtBPTB_read.Rows
                If row(3) = row2(0) Then
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next
            'BEAM  'L                 
            For Each row2 As DataRow In dtBPLB_read.Rows
                If row(3) = row2(0) Then
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next

            no_count = no_count + 1
        Next
        'ProgressBar
        ProgressBar_read.Value = lines.Length() + (lines.Length() / 100) * 7
        '''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'MATERIAL NUMBER ASSIGNING 
        no_count = 0
        For Each row As DataRow In dtBEAM_arrange.Rows
            Dim no_count2 As Integer = 1
            For Each row2 As DataRow In dtMATERIAL_arrange.Rows
                If row(2) = row2(2) Then
                    dtBEAM_arrange.Rows(no_count).Item("iMAT") = no_count2
                End If
                no_count2 = no_count2 + 1
            Next
            no_count = no_count + 1
        Next

        'SECTION NUMBER ASSIGNING
        no_count = 0
        For Each row As DataRow In dtBEAM_arrange.Rows
            Dim no_count2 As Integer = 1
            For Each row2 As DataRow In dtSECTION_arrange.Rows
                If row(3) = row2(2) Then
                    dtBEAM_arrange.Rows(no_count).Item("iPRO") = no_count2
                End If
                no_count2 = no_count2 + 1
            Next
            no_count = no_count + 1
        Next

        'IF NO PROPERTY OR MATERIAL PRESENT DEFULT IT TO 1 1 ' put message Box(Remove this and debug)
        For Each row As DataRow In dtBEAM_arrange.Rows
            If row(2) = "material" Then
                row(2) = "1"
            End If
            If row(3) = "property" Or row(3) = "Beam" Or row(3) = "Column" Then
                row(3) = "1"
            End If
        Next

        'ProgressBar
        ProgressBar_read.Value = lines.Length() + (lines.Length() / 100) * 8
        '''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'PLATES
        Dim nodes As New List(Of String)()
        no_count = 0
        Dim Len_row As Integer = dtOGA_read.Rows.Count() * 1000000 ''''For New plate numbering
        Dim list_nodIndx As New List(Of Integer)
        Dim check_no_count As Integer = 0 'for while
        For Each row As DataRow In dtOGA_read.Rows
            check_no_count = 0
            If row(1) <= 4 Then
                If row(1) = 3 Then
                    dtPLATE_arrange.Rows.Add(row(0), "PLATE", "MATERIAL", "PROPERTY", row(2), row(3), row(4), "0", "1", "0", row(0), row(8))
                    no_count = no_count + 1
                ElseIf row(1) = 4 Then '4 Noded
                    dtPLATE_arrange.Rows.Add(row(0), "PLATE", "MATERIAL", "PROPERTY", row(2), row(3), row(4), row(5), "1", "0", row(0), row(8))
                    no_count = no_count + 1
                End If
            ElseIf CInt(row(1)) > 4 And row(7) <> "NIL" Then
                '''More then 4 Noded converting to 3 Noded triangles list
                Dim NumPoints_count As Integer = CInt(row(1))
                While True
                    check_no_count = 1
                    If NumPoints_count >= 4 Then
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point1"))
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point2"))
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point3"))
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point4"))
                        no_count = no_count + 1
                        NumPoints_count = NumPoints_count - 4

                    ElseIf NumPoints_count = 3 Then
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point1"))
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point2"))
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point3"))
                        no_count = no_count + 1
                        NumPoints_count = NumPoints_count - 3

                    ElseIf NumPoints_count = 2 Then
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point1"))
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point2"))
                        no_count = no_count + 1
                        NumPoints_count = NumPoints_count - 2
                    ElseIf NumPoints_count = 1 Then
                        list_nodIndx.Add(dtOGA_read.Rows(no_count).Item("Point1"))
                        no_count = no_count + 1
                        NumPoints_count = NumPoints_count - 1
                    End If
                    If NumPoints_count = 0 Then
                        Exit While
                    End If
                End While

                Dim m_Points() As PointF = {}
                ReDim Preserve m_Points(list_nodIndx.Count - 1)
                Dim rn As Integer = 0
                Dim j As Integer = 0

                For Each num In list_nodIndx
                    For Each node_no As DataRow In dtNODE_arrange.Rows
                        If Convert.ToString(num) = Convert.ToString(node_no(0)) Then
                            AddVertex(node_no(1), node_no(2), node_no(3))
                            m_Points(j) = New PointF(CSng(node_no(1)), CSng(node_no(2)))
                            j = j + 1
                        End If
                    Next
                Next
                Dim N_trgl_index() As String = CalculateTriangles()
                For k = 0 To N_trgl_index.Count - 1
                    Dim nodes_array_index() As String = N_trgl_index(k).Split(",")
                    For l = 0 To nodes_array_index.Count - 1 Step 3
                        row(2) = list_nodIndx(nodes_array_index(l)) : row(3) = list_nodIndx(nodes_array_index(l + 1)) : row(4) = list_nodIndx(nodes_array_index(l + 2))
                        Dim chk_inside As Integer = 0
                        Dim cgx As Single = 0 : Dim cgy As Single = 0
                        Dim chk_1 As Integer = 0 : Dim chk_2 As Integer = 0 : Dim chk_3 As Integer = 0

                        For lp_var = 0 To dtNODE_arrange.Rows.Count - 1
                            If Convert.ToString(list_nodIndx(nodes_array_index(l))) = Convert.ToString(dtNODE_arrange.Rows(lp_var).Item("iNO")) Then
                                cgx = cgx + dtNODE_arrange.Rows(lp_var).Item("X") / 3 : cgy = cgy + dtNODE_arrange.Rows(lp_var).Item("Y") / 3
                                chk_1 = 1
                            End If
                            If Convert.ToString(list_nodIndx(nodes_array_index(l + 1))) = Convert.ToString(dtNODE_arrange.Rows(lp_var).Item("iNO")) Then
                                cgx = cgx + dtNODE_arrange.Rows(lp_var).Item("X") / 3 : cgy = cgy + dtNODE_arrange.Rows(lp_var).Item("Y") / 3
                                chk_1 = 2
                            End If
                            If Convert.ToString(list_nodIndx(nodes_array_index(l + 2))) = Convert.ToString(dtNODE_arrange.Rows(lp_var).Item("iNO")) Then
                                cgx = cgx + dtNODE_arrange.Rows(lp_var).Item("X") / 3 : cgy = cgy + dtNODE_arrange.Rows(lp_var).Item("Y") / 3
                                chk_1 = 3
                            End If
                            If chk_1 = 1 And chk_2 = 1 And chk_3 = 1 Then
                                Exit For
                            End If
                        Next
                        Dim return_chk As Boolean = PointInPolygon(m_Points, cgx, cgy)
                        If return_chk = True Then
                            chk_inside = 1
                        Else
                            chk_inside = 0
                        End If
                        If chk_inside = 1 Then
                            dtPLATE_arrange.Rows.Add(Len_row, "PLATE", "MATERIAL", "PROPERTY", row(2), row(3), row(4), "0", "1", "0", row(0), row(8))
                        End If
                        Len_row = Len_row + 1
                    Next
                Next
                EmptyVertexList()
                list_nodIndx.Clear()
            End If
        Next
        '''''''''''''''''''''''''''''''''''''''
        'ProgressBar
        ProgressBar_read.Value = lines.Length() + (lines.Length() / 100) * 9
        '''''

        ''PLATE MATERIAL PROPERTY assigning
        no_count = 0
        For Each row As DataRow In dtPLATE_arrange.Rows
            'wall
            For Each row2 As DataRow In dtWPA_read.Rows
                If row(10) = row2(0) Then
                    dtPLATE_arrange.Rows(no_count).Item("iPRO") = row2(1)
                    dtPLATE_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next
            'plates All slab properties 
            For Each row2 As DataRow In dtSPA_read.Rows
                If row(10) = row2(0) Then
                    dtPLATE_arrange.Rows(no_count).Item("iPRO") = row2("SlabProp")
                    dtPLATE_arrange.Rows(no_count).Item("iMAT") = row2("SlabProp")
                End If
            Next
            no_count = no_count + 1
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''PLATE : Area property numbering
        no_count = 0
        For Each row As DataRow In dtPLATE_arrange.Rows
            Dim no_count2 As Integer = 1
            For Each row2 As DataRow In dtTHICKNESS_arrange.Rows
                If row("iPRO") = row2(7) Then
                    dtPLATE_arrange.Rows(no_count).Item("iPRO") = no_count2
                End If
                no_count2 = no_count2 + 1
            Next
            no_count = no_count + 1
        Next

        no_count = 0
        For Each row As DataRow In dtPLATE_arrange.Rows
            ' ALL SLAB EXCEPT RIBBED AND WAFFLE
            For Each row2 As DataRow In dtSPSS_read.Rows
                If row("iMAT") = row2(0) Then
                    dtPLATE_arrange.Rows(no_count).Item("iMAT") = row2(2)
                End If
            Next
            'wall
            For Each row2 As DataRow In dtWP_read.Rows
                If row("iMAT") = row2(0) Then
                    dtPLATE_arrange.Rows(no_count).Item("iMAT") = row2(1)
                End If
            Next
            ' RIBBED AND WAFFLE SLABS
            For Each row2 As DataRow In dtSPRW_read.Rows
                If row(10) = row2(0) Then
                    dtPLATE_arrange.Rows(no_count).Item("iMAT") = row2("MatProp")
                End If
            Next
            no_count = no_count + 1
        Next

        ' MATERIAL NUMBERING
        no_count = 0
        For Each row As DataRow In dtPLATE_arrange.Rows
            Dim no_count2 As Integer = 1
            For Each row2 As DataRow In dtMATERIAL_arrange.Rows
                If row("iMAT") = row2(2) Then
                    dtPLATE_arrange.Rows(no_count).Item("iMAT") = no_count2
                End If
                no_count2 = no_count2 + 1
            Next
            no_count = no_count + 1
        Next
        '''''''''''''''''''''''''''''''''''''''''''''''

        'PRESSURE LOAD REASSIGNING FOR PLATES  'Rearrange
        For Each row As DataRow In dtPRESSURE_arrange.Rows
            For Each row2 As DataRow In dtPLATE_arrange.Rows
                If row(0) = row2(10) Then
                    dtPRESSURE_arrange_RA.Rows.Add(row2(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9))
                End If
            Next
        Next

        'SURFACE_SPRINGS
        For Each row As DataRow In dtSoilA_read.Rows
            For Each row_soilPro As DataRow In dtSP_read.Rows
                If row(1) = row_soilPro(0) Then     '0 linear '1 compression  '2 tension
                    dtSURFACESPRING_arrange.Rows.Add(row(0), "PLANAR(FACE)", " ", " ", 1, row_soilPro(1), " ", row(0))
                End If
            Next
        Next

        'SURFACE_SPRING_RA LOAD REASSIGNING FOR PLATES  'RA rearrange
        For Each row As DataRow In dtSURFACESPRING_arrange.Rows
            For Each row2 As DataRow In dtPLATE_arrange.Rows
                If row(0) = row2(10) Then
                    dtSURFACESPRING_arrange_RA.Rows.Add(row2(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7))
                End If
            Next
        Next



        ''BEAM'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '' Rearrangement of All...! 
        no_count = 1
        Dim beam_count As Integer = 0
        For Each row As DataRow In dtBEAM_arrange.Rows
            '''''''''''''''''''''''''''''''''''''''
            '''Write any thing New hear
            '''''''''''''''''''''''''''''''''''''''
            '' Rearrang LINE LOAD ID CHANGES
            For a = 0 To dtBEAMLOAD_arrange.Rows.Count() - 1
                If row(0) = dtBEAMLOAD_arrange.Rows(a).Item("ELEM_LIST") Then
                    dtBEAMLOAD_arrange.Rows(a).Item("ELEM_LIST") = no_count
                End If
            Next

            '''''''''''This must be at the End
            dtBEAM_arrange.Rows(beam_count).Item("iEL") = no_count
            beam_count = beam_count + 1
            no_count = no_count + 1
        Next

        'PLATES      \\no_count   continues for plate number\\
        Dim count_plate As Integer = 0
        For Each row As DataRow In dtPLATE_arrange.Rows
            ''''''''''''''''''''''''''''''''''''
            ''Write any thing new hear
            '''''''''''''''''''''''''''''''
            ''Rearranged element number
            For a = 0 To dtPRESSURE_arrange_RA.Rows.Count() - 1
                If row(0) = dtPRESSURE_arrange_RA.Rows(a).Item("ELEM_LIST") Then
                    dtPRESSURE_arrange_RA.Rows(a).Item("ELEM_LIST") = no_count
                End If
            Next
            'SURFACESPRING Reassing Numbers
            For a = 0 To dtSURFACESPRING_arrange_RA.Rows.Count() - 1
                If row(0) = dtSURFACESPRING_arrange_RA.Rows(a).Item("ELEM_LIST") Then
                    dtSURFACESPRING_arrange_RA.Rows(a).Item("ELEM_LIST") = no_count
                End If
            Next

            '''''''''''This must be at the End 
            dtPLATE_arrange.Rows(count_plate).Item("iEL") = no_count
            count_plate = count_plate + 1
            no_count = no_count + 1
        Next



        'REASSIGNING NODES
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        For a = 0 To dtNODE_arrange.Rows.Count() - 1
            'Beam
            For b = 0 To dtBEAM_arrange.Rows.Count() - 1
                If dtBEAM_arrange.Rows(b).Item("iN1") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtBEAM_arrange.Rows(b).Item("iN1") = a + 1
                End If
                If dtBEAM_arrange.Rows(b).Item("iN2") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtBEAM_arrange.Rows(b).Item("iN2") = a + 1
                End If
            Next
            'Plates
            For b = 0 To dtPLATE_arrange.Rows.Count() - 1
                If dtPLATE_arrange.Rows(b).Item("iN1") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtPLATE_arrange.Rows(b).Item("iN1") = a + 1
                End If
                If dtPLATE_arrange.Rows(b).Item("iN2") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtPLATE_arrange.Rows(b).Item("iN2") = a + 1
                End If
                If dtPLATE_arrange.Rows(b).Item("iN3") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtPLATE_arrange.Rows(b).Item("iN3") = a + 1
                End If
                If dtPLATE_arrange.Rows(b).Item("iN4") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtPLATE_arrange.Rows(b).Item("iN4") = a + 1
                End If
            Next
            'NODELOAD 
            For b = 0 To dtNODELOAD_arrange.Rows.Count() - 1
                If dtNODELOAD_arrange.Rows(b).Item("NODE_LIST") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtNODELOAD_arrange.Rows(b).Item("NODE_LIST") = a + 1
                End If
            Next
            'SPRING POINTS
            For b = 0 To dtSPRINGPOINT_arrange.Rows.Count() - 1
                If dtSPRINGPOINT_arrange.Rows(b).Item("NODE_LIST") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtSPRINGPOINT_arrange.Rows(b).Item("NODE_LIST") = a + 1
                End If
            Next
            ' CONSTRAIN
            For b = 0 To dtCONSTRAIN_arrange.Rows.Count() - 1
                If dtCONSTRAIN_arrange.Rows(b).Item("NODE_LIST") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtCONSTRAIN_arrange.Rows(b).Item("NODE_LIST") = a + 1
                End If
            Next
            'NODALDISPLACEMENT
            For b = 0 To dtPOINTDISPLOAD_arrange.Rows.Count() - 1
                If dtPOINTDISPLOAD_arrange.Rows(b).Item("NODE_LIST") = dtNODE_arrange.Rows(a).Item("iNO") Then
                    dtPOINTDISPLOAD_arrange.Rows(b).Item("NODE_LIST") = a + 1
                End If
            Next

            '''''''''''This must be at the End
            dtNODE_arrange.Rows(a).Item("REFERENCE") = dtNODE_arrange.Rows(a).Item("iNO") '' BACK UP CHECK
            dtNODE_arrange.Rows(a).Item("iNO") = a + 1 'This must be at last
        Next

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ProgressBar_read.Value = lines.Length() + lines.Length() / 10  'Max
    End Function
    Function WRITE_DATA_SAFE()
        'Writing data in file
        ProgressBar_read.Value = ProgressBar_read.Maximum
        out_path = in_path & "\" & only_file_name & ".mgt"
        Using out_file As New StreamWriter(out_path)
            ProgressBar_writing.Minimum = 0
            ProgressBar_writing.Maximum = 10
            '''''''''''''''''''''''''''''''''''
            writing_unitsSAFE(out_file)
            ProgressBar_writing.Value = 1
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''
            writing_nodeSAFE(out_file)
            ProgressBar_writing.Value = 2
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''
            writing_elem_SAFE(out_file)
            ProgressBar_writing.Value = 3
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''
            writing_BoundaryConditions_SAFE(out_file)
            writting_spring_SAFE(out_file)
            ProgressBar_writing.Value = 4
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''
            writing_material_SAFE(out_file)
            ProgressBar_writing.Value = 5
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''
            writing_thickness_SAFE(out_file)
            ProgressBar_writing.Value = 6
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''
            writing_section_SAFE(out_file)
            ProgressBar_writing.Value = 7
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''         
            writing_loadpattern_SAFE(out_file)
            ProgressBar_writing.Value = 9
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''
            writing_load_SAFE(out_file)
            ProgressBar_writing.Value = 10
            Application.DoEvents()
            '''''''''''''''''''''''''''''''''''
            MessageBox.Show("Writting Completed." & vbNewLine & "Location :  " & CStr(out_path))
            Process.Start(out_path)
        End Using

    End Function
    Function SAFE()
        ProgressBar_read.Minimum = 0
        ProgressBar_read.Maximum = lines.Length() + lines.Length() / 10


        'EXTRACT DATA OF SAFE FROM .F2K
        SCRAPE_DATA_SAFE()

        'ARRANGE DATA OF SAFE AS PER GEN
        ARRANGE_DATA_SAFE()

        'WRITE DATA OF SAFE IN FILE
        WRITE_DATA_SAFE()

        'RESETTING ALL
        delete_db_SAFE()
        delete_db()
    End Function

    ''' SAFE FUNCTIONS
    Function writeUnitsSAFE(ByVal s As Integer, ByVal str As String, ByVal patt As String)
        Dim text As String = str
        Dim pattern As String = patt '"\bCurrUnits=(.*)MergeTol\b"
        ' Instantiate the regular expression object.
        Dim r As Regex = New Regex(pattern, RegexOptions.IgnoreCase)
        Dim m As Match = r.Match(text)
        Dim g As Group = m.Groups(1)
        If m.Success Then
            Dim words() As String = g.ToString().Split(New Char() {","c})
            If words(0) = "LB" Then
                words(0) = "LBF"
            End If
            dtCrtdUnits.Rows.Add(words(0), words(1), "BTU", words(2))
        End If
    End Function 'Done
    Function writeNodesSAFE(ByVal s As Integer, ByVal str As String, ByVal patt As String)
        Dim text As String = str
        Dim pattern As String = patt '"\bCurrUnits=(.*)MergeTol\b"
        ' Instantiate the regular expression object.
        Dim r As Regex = New Regex(pattern, RegexOptions.IgnoreCase)
        Dim m As Match = r.Match(text)
        Dim g As Group = m.Groups(1)
        If m.Success Then
            ' Dim words() As String = g.ToString().Split(New Char() {","c}) ' else use direct split
            Console.WriteLine(text)
            PrintLine(s, text)
        End If
    End Function

    '''WRITES
    Public Function writing_unitsSAFE(ByVal out_file As StreamWriter)
        Dim da As String = String.Format("{0:yyyy/M/d}", DateTime.Now)
        Dim da2 As String = ";  Date : " + da

        out_file.WriteLine(";---------------------------------------------------------------------------")
        out_file.WriteLine(";  midas Gen Text(MGT) File.")
        out_file.WriteLine(da2)
        out_file.WriteLine(";---------------------------------------------------------------------------")
        out_file.WriteLine(" ")
        ' out_file.WriteLine("*VERSION")    'SHOW ERROR IN OTHER VERSIONS
        ' out_file.WriteLine("   8.6.0")
        out_file.WriteLine(" ")
        If dtPCunits_read.Rows.Count > 0 Then
            out_file.WriteLine("*UNIT    ; Unit System")
            out_file.WriteLine("; FORCE, LENGTH, HEAT, TEMPER")
            For Each row As DataRow In dtPCunits_read.Rows
                out_file.WriteLine(row("Force") & " , " & row("Dimension") & " , " & row("Heat") & " , " & row("Temperature"))
            Next
        End If
    End Function
    Public Function writing_nodeSAFE(ByVal out_file As StreamWriter)
        If dtNODE_arrange.Rows.Count > 0 Then
            out_file.WriteLine("*NODE    ; Nodes")
            out_file.WriteLine("; iNO, X, Y, Z")
            For Each row As DataRow In dtNODE_arrange.Rows
                'If InStr(row("iNO").ToString(), "P") Then

                'End If
                out_file.WriteLine(row("iNO") & ", " & row("X") & ", " & row("Y") & ", " & row("Z"))
            Next
        End If
    End Function
    ''' SAFE FUNTIONS ENDS



    Public Function parsing_node(ByVal nodenumber As Integer, ByVal pt_x As String, ByVal pt_y As String, ByVal story_height As String, ByVal node_org As String, ByVal story_name As String)
        If story_height = 0 Then
            dtCrtdNode.Rows.Add(nodenumber, pt_x, pt_y, story_height, 1, node_org, story_name)
        Else
            dtCrtdNode.Rows.Add(nodenumber, pt_x, pt_y, story_height, 0, node_org, story_name)
        End If
    End Function

    Public Function parsing_elem_conn(ByVal ele_name As String, ByVal i_end As String, ByVal j_end As String, ByVal flr_var As String)
        dtCrtdElem_conn.Rows.Add(elementnumber, ele_name, i_end, j_end, flr_var)
        elementnumber = elementnumber + 1
    End Function

    Public Function parsing_lineassign(ByVal line_name As String, ByVal story_name As String, ByVal sec_name As String)
        dtcrtdlineassign.Rows.Add(line_name, story_name, sec_name)
    End Function

    Public Function parsing_story(ByVal st_name As String, ByVal st_height As String)
        dtcrtdstoryorg.Rows.Add(st_name, st_height)
    End Function

    Public Function parsing_pointassign(ByVal node As String, ByVal story As String, ByVal dx As String, ByVal dy As String, ByVal dz As String, ByVal rx As String, ByVal ry As String, ByVal rz As String)
        Dim node_pass As String = 0
        node_pass = func_node_converter(node, story)
        If node_pass <> 0 Then
            dtboundary_conditions.Rows.Add(node_pass, dx, dy, dz, rx, ry, rz)
        End If

    End Function

    Public Function parsing_material(ByVal Material_id As Integer, ByVal material_name As String, ByVal Specific_Heat As Double, ByVal Heat_Conduction As Double, ByVal Damping_Ratio As Double, ByVal Modulus_Of_Elasticity As Double, ByVal Poisons_Ratio As Double, ByVal Thermal_Coeff As Double, ByVal Weight_Density As Double, ByVal material_type As String)
        dtMatgrade.Rows.Add(Material_id, material_name, Specific_Heat, Heat_Conduction, Damping_Ratio, Modulus_Of_Elasticity, Poisons_Ratio, Thermal_Coeff, Weight_Density, material_type)
    End Function

    Public Function parsing_section(ByVal sec_id As Integer, ByVal sec_name As String, ByVal sec_mat As String, ByVal sec_mat_name As String, ByVal sec_shape As String, ByVal d1 As Double, ByVal d2 As Double, ByVal d3 As Double, ByVal d4 As Double, ByVal d5 As Double, ByVal d6 As Double, ByVal d7 As Double, ByVal d8 As Double)
        If sec_shape = "Concrete Circle" Then
            sec_shape = "SR"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, 0, 0, 0, 0, 0, 0, 0)
        ElseIf sec_shape = "Steel I/Wide Flange" Then
            sec_shape = "H"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d2, d3, 0, 0)
        ElseIf sec_shape = "Steel Channel" Then
            sec_shape = "C"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d2, d3, 0, 0)
        ElseIf sec_shape = "Steel Tee" Then
            sec_shape = "T"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d2, d3, 0, 0)
        ElseIf sec_shape = "Steel Angle" Then
            sec_shape = "L"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, 0, 0, 0, 0)
        ElseIf sec_shape = "Steel Double Angle" Then
            sec_shape = "2L"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, 0, 0, 0)
        ElseIf sec_shape = "Steel Double Channel" Then
            sec_shape = "2C"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, 0, 0, 0)
            'ElseIf sec_shape = "Steel Tube" Then
            '    sec_shape = "H"
            '    dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, d6, 0, 0)
        ElseIf sec_shape = "Steel Pipe" Then
            sec_shape = "P"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, 0, 0, 0, 0, 0, 0)
            'ElseIf sec_shape = "Filled Steel Tube" Then
            '    sec_shape = "H"
            '    dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, d6, 0, 0)
            'ElseIf sec_shape = "Filled Steel Pipe" Then
            '    sec_shape = "H"
            '    dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, d6, 0, 0)
        ElseIf sec_shape = "Concrete Rectangular" Then
            sec_shape = "SB"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, d6, 0, 0)
        ElseIf sec_shape = "Steel Box" Then
            sec_shape = "B"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, 0, d3, 0, 0)
        ElseIf sec_shape = "Filled" Then
            sec_shape = "B"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, 0, d3, 0, 0)
        ElseIf sec_shape = "Concrete Encasement Rectangle" Then
            sec_shape = "SB"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, d6, 0, 0)
        ElseIf sec_shape = "Filled Steel Tube" Or sec_shape = "Steel Tube" Then
            sec_shape = "SB"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, d6, 0, 0)
        ElseIf sec_shape = "Filled Steel Pipe" Then
            sec_shape = "SB"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, d4, d3, d5, d6, 0, 0)
        Else
            sec_shape = "SB"
            dtProSectionUndef.Rows.Add(sec_id, sec_name, sec_mat_name)
            sec_name = sec_name + "*"
            dtProSection.Rows.Add(sec_id, sec_name, sec_mat, sec_mat_name, sec_shape, d1, d2, 0, 0, 0, 0, 0, 0)

        End If
    End Function
    'Dim sec_id_mod As Integer = 0
    Public Function parsing_modifier(ByVal sec_name As String, ByVal mods As String)
        Dim mod_brk() As String = mods.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)

        For l1 = 0 To dtProSection.Rows.Count - 1
            If sec_name = dtProSection.Rows(l1).Item("Section_name") Or CStr(sec_name + "*") = dtProSection.Rows(l1).Item("Section_name") Then
                'sec_id_mod = sec_id_mod + 1
                Dim area_sf As String = "1"
                Dim asy_sf As String = "1"
                Dim asz_sf As String = "1"
                Dim ixx_sf As String = "1"
                Dim iyy_sf As String = "1"
                Dim izz_sf As String = "1"
                Dim wgt_sf As String = "1"
                For i = 0 To mod_brk.Count - 1 Step 2
                    mod_brk(i) = mod_brk(i).Trim
                    If mod_brk(i) = "AMOD" Then
                        area_sf = mod_brk(i + 1)
                    ElseIf mod_brk(i) = "A2MOD" Then
                        asy_sf = mod_brk(i + 1)
                    ElseIf mod_brk(i) = "A3MOD" Then
                        asz_sf = mod_brk(i + 1)
                    ElseIf mod_brk(i) = "JMOD" Then
                        ixx_sf = mod_brk(i + 1)
                    ElseIf mod_brk(i) = "I2MOD" Then
                        iyy_sf = mod_brk(i + 1)
                    ElseIf mod_brk(i) = "I3MOD" Then
                        izz_sf = mod_brk(i + 1)
                    ElseIf mod_brk(i) = "WMOD" Then
                        wgt_sf = mod_brk(i + 1)
                    End If
                Next
                dtmodifier.Rows.Add(dtProSection.Rows(l1).Item("Section_id"), area_sf, asy_sf, asz_sf, ixx_sf, iyy_sf, izz_sf, "1", wgt_sf)
            End If
        Next
    End Function

    Public Function parsing_loadpattern(ByVal lp_id As Integer, ByVal pattern_name As String, ByVal pattern_type As String)                 'JUST CHECK IF THE LOAD PATTERNS ARE MATCHING WITH ETABS INPUT FILE
        If pattern_type = "Dead" Then
            pattern_type = "D"
        ElseIf pattern_type = "Live" Then
            pattern_type = "L"
        ElseIf pattern_type = "Wind" Then
            pattern_type = "W"
        ElseIf pattern_type = "Seismic" Then
            pattern_type = "E"
        ElseIf pattern_type = "Other" Then
            pattern_type = "USER"
        ElseIf pattern_type = "Roof Live" Then
            pattern_type = "LR"
        ElseIf pattern_type = "Snow" Then
            pattern_type = "S"
        ElseIf pattern_type = "Construction" Then
            pattern_type = "CS"
        ElseIf pattern_type = "Super dead" Then
            pattern_type = "D"
        Else
            pattern_type = "USER"
        End If
        dtload_pattern.Rows.Add(lp_id, pattern_name, pattern_type)
    End Function

    Public Function parsing_pointload(ByVal p_id As Integer, ByVal node As Integer, ByVal story As String, ByVal load_name As String, ByVal prtid As String)
        Dim node_pass As String
        Dim n As Integer = 0
        Dim FX_V As Double
        Dim FY_V As Double
        Dim FZ_V As Double
        Dim MX_V As Double
        Dim MY_V As Double
        Dim MZ_V As Double
        node_pass = func_node_converter(node, story)
        Dim prtid_1() As String = prtid.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)

        For i = 0 To prtid_1.Count - 1 Step 2
            If prtid_1(i) = "FX" Then
                FX_V = prtid_1(i + 1)
            End If
            If prtid_1(i) = "FY" Then
                FY_V = prtid_1(i + 1)
            End If
            If prtid_1(i) = "FZ" Then
                FZ_V = prtid_1(i + 1)
            End If
            If prtid_1(i) = "MX" Then
                MX_V = prtid_1(i + 1)
            End If
            If prtid_1(i) = "MX" Then
                MY_V = prtid_1(i + 1)
            End If
            If prtid_1(i) = "MX" Then
                MZ_V = prtid_1(i + 1)
            End If
        Next
        dtNodalLoads.Rows.Add(p_id, node_pass, FX_V, FY_V, FZ_V, MX_V, MY_V, MZ_V, load_name)
    End Function

    Public Function parsing_lineload(ByVal ele_type As String, ByVal story As String, ByVal lc_name As String, ByVal lc_dir As String, ByVal p01 As String, ByVal p02 As String, ByVal p03 As Double, ByVal p04 As Double, ByVal p11 As String, ByVal p12 As String, ByVal p13 As String, ByVal p14 As String, ByVal p21 As String, ByVal p22 As String, ByVal p23 As Double, ByVal p24 As Double, ByVal tp_to_prt As String)
        Dim ele_number_pass As Integer
        Dim d1 As Double
        Dim p1 As Double
        Dim d2 As Double
        Dim p2 As Double
        Dim d3 As Double
        Dim p3 As Double
        Dim d4 As Double
        Dim p4 As Double
        Dim proj As String = "NO"
        ele_number_pass = func_element_converter(ele_type, story)
        If lc_dir = "GRAV" Then
            lc_dir = "GZ"
            p01 = -p01
            p02 = -p02
            p21 = -p21
            p22 = -p22
        End If
        If lc_dir = "XPROJ" Then
            lc_dir = "GX"
            proj = "YES"
        End If
        If lc_dir = "YPROJ" Then
            lc_dir = "GY"
            proj = "YES"
        End If
        If lc_dir = "GRAVPROJ" Then
            lc_dir = "GZ"
            p01 = -p01
            p02 = -p02
            p21 = -p21
            p22 = -p22
            proj = "YES"
        End If
        If lc_dir = "1" Then
            lc_dir = "LX"
        End If
        If lc_dir = "2" Then
            lc_dir = "LZ"
        End If
        If lc_dir = "3" Then
            lc_dir = "LY"
            p01 = -p01
            p02 = -p02
            p21 = -p21
            p22 = -p22
        End If
        If lc_dir = "X" Then
            lc_dir = "GX"
        End If
        If lc_dir = "Y" Then
            lc_dir = "GY"
        End If

        d1 = Math.Round(p03, 1, MidpointRounding.AwayFromZero)
        p1 = p01
        d2 = Math.Round(p04, 1, MidpointRounding.AwayFromZero)
        p2 = p02
        d3 = Math.Round(p23, 1, MidpointRounding.AwayFromZero)
        p3 = p21
        d4 = Math.Round(p24, 1, MidpointRounding.AwayFromZero)
        p4 = p22

        If ele_number_pass <> 0 Then
            dtbeam_loads.Rows.Add(ele_number_pass, lc_dir, d1, p1, d2, p2, d3, p3, d4, p4, lc_name, tp_to_prt, proj)
        End If
    End Function

    Public Function parsing_areaassign(ByVal area_name As String, ByVal area_story As String, ByVal area_section As String)
        dtarea_assign.Rows.Add(area_name, area_story, area_section)
    End Function

    Public Function parsing_area_conn(ByVal area_name As String, ByVal node_us() As String, ByVal floor_Chk As String, ByVal chker As Integer)
        If node_us.Count = 3 Then
            dtarea_conn.Rows.Add(elementnumber, 0, 0, node_us(0), node_us(1), node_us(2), 0, 1, 0, area_name, floor_Chk, chker)
            elementnumber = elementnumber + 1
        End If
        If node_us.Count = 4 Then
            dtarea_conn.Rows.Add(elementnumber, 0, 0, node_us(0), node_us(1), node_us(2), node_us(3), 1, 0, area_name, floor_Chk, chker)
            elementnumber = elementnumber + 1
        End If

    End Function

    Public Function parsing_thickness(ByVal th_id As String, ByVal th_name As String, ByVal th_mat As String, ByVal th_depth As String)
        dtthickness.Rows.Add(th_id, th_name, th_mat, th_depth)

    End Function

    Public Function parsing_areaload(ByVal Area_name As String, ByVal Area_story As String, ByVal Area_type As String, ByVal Area_dir As String, ByVal Area_loadcase As String, ByVal Area_load_mag As String)
        dt_area_load_etabs.Rows.Add(Area_name, Area_story, Area_type, Area_dir, Area_loadcase, Area_load_mag)
    End Function

    Public Function parsing_loadset(ByVal ld_name As String, ByVal ld_pat As String, ByVal ld_mag As String)
        dt_loadset.Rows.Add(ld_name, ld_pat, ld_mag)
    End Function

    Public Function parsing_pointsprings(ByVal sp_name As String, ByVal sp_val As String)
        sp_val = sp_val.Trim()
        Dim sp_val_brk As String() = sp_val.Split(" ".ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        Dim p_ux As String = "1e+014"
        Dim p_uy As String = "1e+014"
        Dim p_uz As String = "1e+014"
        Dim p_rx As String = "1e+016"
        Dim p_ry As String = "1e+016"
        Dim p_rz As String = "1e+016"

        For l1 = 0 To sp_val_brk.Count - 1 Step 2
            If sp_val_brk(l1) = "UX" Then
                p_ux = sp_val_brk(l1 + 1)
            End If
            If sp_val_brk(l1) = "UY" Then
                p_uy = sp_val_brk(l1 + 1)
            End If
            If sp_val_brk(l1) = "UZ" Then
                p_uz = sp_val_brk(l1 + 1)
            End If
            If sp_val_brk(l1) = "RX" Then
                p_rx = sp_val_brk(l1 + 1)
            End If
            If sp_val_brk(l1) = "RY" Then
                p_ry = sp_val_brk(l1 + 1)
            End If
            If sp_val_brk(l1) = "RZ" Then
                p_rz = sp_val_brk(l1 + 1)
            End If
        Next

        dt_pointspring.Rows.Add(sp_name, p_ux, p_uy, p_uz, p_rx, p_ry, p_rz)
    End Function

    Public Function parsing_pointassign_spring(ByVal sp_node As String, ByVal sp_story As String, ByVal sp_name As String)
        If dt_pointspring.Rows.Count > 0 Then
            Dim node_pass As Integer = func_node_converter(sp_node, sp_story)
            For l1 = 0 To dt_pointspring.Rows.Count - 1
                If dt_pointspring.Rows(l1).Item("Spring_name") = sp_name Then
                    dt_springs.Rows.Add(node_pass, dt_pointspring.Rows(l1).Item("UX"), dt_pointspring.Rows(l1).Item("UY"), dt_pointspring.Rows(l1).Item("UZ"), dt_pointspring.Rows(l1).Item("RX"), dt_pointspring.Rows(l1).Item("RY"), dt_pointspring.Rows(l1).Item("RZ"))
                    Exit For
                End If
            Next
        End If
    End Function

    Public Function writing_units(ByVal out_file As StreamWriter)
        out_file.WriteLine(";---------------------------------------------------------------------------")
        out_file.WriteLine(";  midas Gen Text(MGT) File.")
        out_file.WriteLine(";  Date : ")
        out_file.WriteLine(";---------------------------------------------------------------------------")
        out_file.WriteLine(" ")
        out_file.WriteLine("*VERSION")
        out_file.WriteLine("   8.4.5")
        out_file.WriteLine(" ")
        If dtCrtdUnits.Rows.Count > 0 Then
            out_file.WriteLine("*UNIT")
            For Each row As DataRow In dtCrtdUnits.Rows
                out_file.WriteLine(row("Force") & " , " & row("Length") & " , " & row("Heat") & " , " & row("Temper"))
            Next
        End If
    End Function


    Public Function writing_node(ByVal out_file As StreamWriter)
        If dtCrtdNode.Rows.Count > 0 Then
            out_file.WriteLine("*NODE")
            Dim ck As Integer = 0
            For Each row As DataRow In dtCrtdNode.Rows
                If dtCrtdNode.Rows(ck).Item("IS_PASSING") = 1 Then
                    out_file.WriteLine(row("Node_Number") & ", " & row("X") & ", " & row("Y") & ", " & row("Z"))
                End If
                ck = ck + 1
            Next
        End If
    End Function


    Public Function writing_elem(ByVal out_file As StreamWriter)
        If dtCrtdElem.Rows.Count > 0 Or dtarea_ele_pass.Rows.Count > 0 Then
            out_file.WriteLine("*ELEMENT")
        End If
        Dim f_ele As Integer = 1
        If dtCrtdElem.Rows.Count > 0 Then
            For Each row As DataRow In dtCrtdElem.Rows
                out_file.WriteLine(f_ele.ToString() & ", BEAM ,     " & row("Material") & ",    " & row("Section") & ", " & row("N1") & ", " & row("N2") & ", " & "0" & ",  " & "0")
                dt_final_element_list.Rows.Add(f_ele, "0", "0")
                f_ele = f_ele + 1
            Next
        End If
        If dtarea_ele_pass.Rows.Count > 0 Then
            final_plate_count_start = f_ele
            For Each row As DataRow In dtarea_ele_pass.Rows
                out_file.WriteLine(f_ele.ToString() & ", PLATE ,     " & row("Material") & ",    " & row("Property") & ", " & row("N1") & ", " & row("N2") & ", " & row("N3") & ", " & row("N4") & ", " & row("SUB") & ",  " & row("WID"))
                dt_final_element_list.Rows.Add(f_ele, row("Orignal_area_name"), row("Orignal_area_story"))
                f_ele = f_ele + 1
            Next
        End If
    End Function


    Public Function writing_elem_SAFE(ByVal out_file As StreamWriter)
        If dtPLATE_arrange.Rows.Count > 0 Or dtBEAM_arrange.Rows.Count > 0 Then 'CHANGE THIS
            out_file.WriteLine("*ELEMENT")
        End If

        'BEAMS COLUMNS
        If dtBEAM_arrange.Rows.Count > 0 Then
            For Each row As DataRow In dtBEAM_arrange.Rows
                out_file.WriteLine(row("iEL") & ",  " & row("TYPEbLMT") & ",    " & row("iMAT") & ",    " & row("iPRO") & _
                                   ", " & row("iN1") & ", " & row("iN2") & _
                                   ", " & row("ANGLE") & ", " & row("iSUB"))
            Next
        End If


        'PLATE
        ''''''''
        If dtPLATE_arrange.Rows.Count > 0 Then  ' PLATE
            For Each row As DataRow In dtPLATE_arrange.Rows
                out_file.WriteLine(row("iEL") & ",  " & row("TYPE") & ",    " & row("iMAT") & ",    " & row("iPRO") & _
                                   ", " & row("iN1") & ", " & row("iN2") & ", " & row("iN3") & ", " & row("iN4") & _
                                   ", " & row("iSUB") & ", " & row("iWID"))
            Next
        End If

    End Function
    'Public Function writing_story(ByVal out_file As StreamWriter)
    '    If dtStorydata.Rows.Count > 0 Then
    '        out_file.WriteLine("*STORY")
    '        Dim n As Single = 0
    '        Dim col1 As Single = Math.Round((dtCrtdNode.Compute("MAX(X)", Nothing) - dtCrtdNode.Compute("MIN(X)", Nothing)), 3, MidpointRounding.AwayFromZero)
    '        Dim col2 As Single = Math.Round((dtCrtdNode.Compute("MAX(Y)", Nothing) - dtCrtdNode.Compute("MIN(Y)", Nothing)), 3, MidpointRounding.AwayFromZero)
    '        Dim col3 As Single = 0.5 * Math.Round((dtCrtdNode.Compute("MAX(X)", Nothing) - dtCrtdNode.Compute("MIN(X)", Nothing)), 3, MidpointRounding.AwayFromZero)
    '        Dim col4 As Single = 0.5 * Math.Round((dtCrtdNode.Compute("MAX(Y)", Nothing) - dtCrtdNode.Compute("MIN(Y)", Nothing)), 3, MidpointRounding.AwayFromZero)
    '        Dim col5 As Single = 0.05 * Math.Round((dtCrtdNode.Compute("MAX(X)", Nothing) - dtCrtdNode.Compute("MIN(X)", Nothing)), 3, MidpointRounding.AwayFromZero)
    '        Dim col6 As Single = 0.05 * Math.Round((dtCrtdNode.Compute("MAX(Y)", Nothing) - dtCrtdNode.Compute("MIN(Y)", Nothing)), 3, MidpointRounding.AwayFromZero)
    '        Dim col7 As Single = 0.15 * Math.Round((dtCrtdNode.Compute("MAX(X)", Nothing) - dtCrtdNode.Compute("MIN(X)", Nothing)), 3, MidpointRounding.AwayFromZero)
    '        Dim col8 As Single = 0.15 * Math.Round((dtCrtdNode.Compute("MAX(Y)", Nothing) - dtCrtdNode.Compute("MIN(Y)", Nothing)), 3, MidpointRounding.AwayFromZero)

    '        For Each row As DataRow In dtStorydata.Rows
    '            If dtStorydata.Rows(n).Item("Story_height") = 0 Then
    '                out_file.WriteLine("BASE" & " ,  " & row("Story_height") & ", NO," & col1 & " ,  " & col2 & " ,  " & col3 & " ,  " & col4 & " ,  " & col5 & " ,  " & col6 & " ,0,0,1,1,  " & col7 & " ,  " & col8 & ", 0")
    '            ElseIf n < dtStorydata.Rows.Count - 1 Then
    '                out_file.WriteLine(row("Story_name") & " ,  " & row("Story_height") & ", YES," & col1 & " ,  " & col2 & " ,  " & col3 & " ,  " & col4 & " ,  " & col5 & " ,  " & col6 & " , 0, 0, 1, 1,  " & col7 & " ,  " & col8 & ", 0")
    '            Else
    '                out_file.WriteLine("ROOF" & " ,  " & row("Story_height") & ", YES," & col1 & " ,  " & col2 & " ,  " & col3 & " ,  " & col4 & " ,  " & col5 & " ,  " & col6 & " , 0, 0, 1, 1,  " & col7 & " ,  " & col8 & ", 0")
    '            End If
    '            n = n + 1
    '        Next
    '    End If
    'End Function

    Public Function writing_BoundaryConditions(ByVal out_file As StreamWriter)
        If dtboundary_conditions.Rows.Count > 0 Then
            out_file.WriteLine("*CONSTRAINT")
            For Each row As DataRow In dtboundary_conditions.Rows
                out_file.WriteLine(row("Node_Number") & ",  " & row("Dx") & row("Dy") & row("Dz") & row("Rx") & row("Ry") & row("Rz"))
            Next
        End If
    End Function
    Public Function writing_BoundaryConditions_SAFE(ByVal out_file As StreamWriter)
        If dtCONSTRAIN_arrange.Rows.Count > 0 Then
            out_file.WriteLine("*CONSTRAINT")
            For Each row As DataRow In dtCONSTRAIN_arrange.Rows
                out_file.WriteLine(row("NODE_LIST") & ",  " & row("Dx") & row("Dy") & row("Dz") & row("Rx") & row("Ry") & row("Rz"))
            Next
        End If
    End Function

    Public Function writing_material(ByVal out_file As StreamWriter)
        If dtMatgrade.Rows.Count > 0 Then
            out_file.WriteLine("*MATERIAL")
            For Each row As DataRow In dtMatgrade.Rows
                out_file.WriteLine(row("Material_id") & ", " & row("Material_type") & ", " & row("Material_name") & ", " & row("Specific_Heat") & ", " & row("Heat_Conduction") & ", , C,NO," & row("Damping_Ratio") & ", 2," & row("Modulus_Of_Elasticity") & ",   " & row("Poisons_Ratio") & ",    " & row("Thermal_Coeff") & ",   " & row("Weight_Density") & "    ,0")
            Next
        End If
    End Function
    Public Function writing_material_SAFE(ByVal out_file As StreamWriter)
        If dtMATERIAL_arrange.Rows.Count > 0 Then
            out_file.WriteLine("*MATERIAL")
            For Each row As DataRow In dtMATERIAL_arrange.Rows
                out_file.WriteLine(row("iMAT") & ", " & row("TYPE") & ", " & row("MNAME") & ", " & row("SPHEAT") & _
                                   ", " & row("HEATCO") & ",   " & row("PLAST") & ",   " & row("TUNIT") & ",   " & row("bMASS") & ",   " & row("DAMPRATIO") & _
                                   ",    " & row("ELAST_or_2") & ",   " & row("ELAST") & ",   " & row("POISN") & ",   " & row("THERMAL") & _
                                   ",    " & row("CODE") & ",   " & row("DEN") & ",   " & row("MASS"))
            Next
        End If
    End Function


    Public Function writing_section(ByVal out_file As StreamWriter)
        If dtProSection.Rows.Count > 0 Then
            out_file.WriteLine("*SECTION")
            For Each row As DataRow In dtProSection.Rows
                out_file.WriteLine(row("Section_id") & ",  DBUSER ," & row("Section_name") & "   ,CC, 0, 0, 0, 0, 0, 0, YES, " & row("Section_shape") & ", 2, " & row("d1") & ",  " & row("d2") & ", " & row("d3") & ", " & row("d4") & ", " & row("d5") & ",  " & row("d6") & ", " & row("d7") & ", " & row("d8"))
            Next
        End If
    End Function

    Public Function writing_section_SAFE(ByVal out_file As StreamWriter)
        If dtSECTION_arrange.Rows.Count > 0 Then
            out_file.WriteLine("*SECTION")
            For Each row As DataRow In dtSECTION_arrange.Rows
                out_file.WriteLine(row("iSEC") & "," & row("TYPE") & "," & row("SNAME") & "," & row("OFFSET_GROUP") & "," & row("DB") & "," & row("NAME") & "," & row("D1_D") & "," & row("D2_B") & "," & row("D3") & "," & row("D4") & "," & row("D5") & "," & row("D6") & "," & row("D7") & "," & row("D8") & "," & row("D9") & "," & row("D10"))
            Next
        End If
    End Function
    Public Function writing_load(ByVal out_file As StreamWriter)
        If dtload_pattern.Rows.Count > 0 Then
            Dim ck1 As Integer = 0
            Dim ck2 As Integer = 0
            Dim ck3 As Integer = 0
            Dim ck4 As Integer = 0
            Dim sw As Integer = 0
            For Each row As DataRow In dtload_pattern.Rows
                out_file.WriteLine("*USE-STLD,   " & row("Pattern_name"))
                If dtload_pattern.Rows(ck1).Item("Pattern_type") = "D" And sw = 0 Then
                    out_file.WriteLine("*SELFWEIGHT, 0, 0, -1,")
                    sw = 1
                End If

                ck2 = 0
                Dim sck2 As Integer = 0
                For Each row2 As DataRow In dtNodalLoads.Rows
                    If dtNodalLoads.Rows(ck2).Item("LC_NAME") = dtload_pattern.Rows(ck1).Item("Pattern_name") Then
                        If sck2 = 0 Then
                            out_file.WriteLine("*CONLOAD")
                            sck2 = 1
                        End If
                        out_file.WriteLine(row2("Node_number") & ", " & row2("FX") & ", " & row2("FY") & ", " & row2("FZ") & ", " & row2("MX") & ", " & row2("MY") & ", " & row2("MZ"))
                    End If
                    ck2 = ck2 + 1
                Next
                ck3 = 0
                Dim sck3 As Integer = 0
                For Each row3 As DataRow In dtbeam_loads.Rows
                    If dtbeam_loads.Rows(ck3).Item("LC_NAME") = dtload_pattern.Rows(ck1).Item("Pattern_name") Then
                        If sck3 = 0 Then
                            out_file.WriteLine("*BEAMLOAD")
                            sck3 = 1
                        End If
                        out_file.WriteLine(row3("Element_number") & ", BEAM ," & row3("Type_to_print") & ", " & row3("Loading_direction") & ", " & row3("Projection") & ", NO,aDir[1], , , , " & row3("d1") & ", " & row3("p1") & ", " & row3("d2") & ", " & row3("p2") & ", " & row3("d3") & ", " & row3("p3") & ", " & row3("d4") & ", " & row3("p4") & ", , NO, 0, 0, NO,")
                    End If
                    ck3 = ck3 + 1
                Next
                ck4 = 0
                Dim sck4 As Integer = 0
                If dt_area_load_etabs.Rows.Count > 0 Then
                    For n_area_etabs = 0 To dt_area_load_etabs.Rows.Count - 1
                        If dt_area_load_etabs.Rows(n_area_etabs).Item("Area_loadcase") = dtload_pattern.Rows(ck1).Item("Pattern_name") Then
                            If sck4 = 0 Then
                                out_file.WriteLine(" ")
                                out_file.WriteLine("*PRESSURE")
                                sck4 = 1
                            End If
                            Dim neg_chk As Integer = 0
                            For n_area_ele = final_plate_count_start - 1 To dt_final_element_list.Rows.Count - 1
                                If CStr(dt_area_load_etabs.Rows(n_area_etabs).Item("Area_name") & "_" & dt_area_load_etabs.Rows(n_area_etabs).Item("Area_story")) = CStr(dt_final_element_list.Rows(n_area_ele).Item("Final_org_name") & "_" & dt_final_element_list.Rows(n_area_ele).Item("Final_org_story")) Then
                                    Dim lc_dir As String = dt_area_load_etabs.Rows(n_area_etabs).Item("Area_dir")
                                    Dim proj As String = "NO"
                                    If lc_dir = "GRAV" Then
                                        lc_dir = "GZ"
                                        neg_chk = 1
                                    End If
                                    If lc_dir = "XPROJ" Then
                                        lc_dir = "GX"
                                        proj = "YES"
                                    End If
                                    If lc_dir = "YPROJ" Then
                                        lc_dir = "GY"
                                        proj = "YES"
                                    End If
                                    If lc_dir = "GRAVPROJ" Then
                                        lc_dir = "GZ"
                                        proj = "YES"
                                        neg_chk = 1
                                    End If
                                    If lc_dir = "1" Then
                                        lc_dir = "LX"
                                    End If
                                    If lc_dir = "2" Then
                                        lc_dir = "LY"
                                    End If
                                    If lc_dir = "3" Then
                                        lc_dir = "LZ"
                                    End If
                                    If lc_dir = "X" Then
                                        lc_dir = "GX"
                                    End If
                                    If lc_dir = "Y" Then
                                        lc_dir = "GY"
                                    End If
                                    If neg_chk = 0 Then
                                        If CStr(dt_area_load_etabs.Rows(n_area_etabs).Item("Area_load_mag")) <> "0" Then
                                            out_file.WriteLine(dt_final_element_list.Rows(n_area_ele).Item("Final_reference") & ", PRES, PLATE, FACE, " & lc_dir & ", 0, 0, 0, " & proj & ", " & dt_area_load_etabs.Rows(n_area_etabs).Item("Area_load_mag") & ", 0, 0, 0, 0,")
                                        End If
                                        'If dt_area_load_etabs.Rows.Count > 3 Then
                                        '    dt_area_load_etabs.Rows(n_area_etabs).Delete()
                                        'End If
                                    End If
                                    If neg_chk = 1 Then
                                        If CStr(dt_area_load_etabs.Rows(n_area_etabs).Item("Area_load_mag")) <> "0" Then
                                            out_file.WriteLine(dt_final_element_list.Rows(n_area_ele).Item("Final_reference") & ", PRES, PLATE, FACE, " & lc_dir & ", 0, 0, 0, " & proj & ", " & dt_area_load_etabs.Rows(n_area_etabs).Item("Area_load_mag") & ", 0, 0, 0, 0,")
                                        End If
                                        'If dt_area_load_etabs.Rows.Count > 3 Then
                                        '    dt_area_load_etabs.Rows(n_area_etabs).Delete()
                                        'End If
                                    End If
                                End If
                                Application.DoEvents()
                            Next n_area_ele
                        End If
                        Application.DoEvents()
                    Next
                End If
                ck1 = ck1 + 1
                Application.DoEvents()
            Next
        End If
    End Function

    Public Function writing_load_SAFE(ByVal out_file As StreamWriter)
        For Each row As DataRow In dtLP_read.Rows
            out_file.WriteLine("*USE-STLD," & " " & row(0))
            If row(2) = 1 Then
                out_file.WriteLine("*SELFWEIGHT, 0, 0," & "-" & row(2) & ",") ' ask one in SAFE is -1
            End If
            ''''Conversion
            If row(1) = "D" Or row(1) = "DEAD" Then
                row(1) = "DEAD"
            ElseIf row(1) = "L" Or row(1) = "LIVE" Then
                row(1) = "LIVE"
            ElseIf row(1) = "E" Or row(1) = "QUAKE" Then
                row(1) = "QUAKE"
            ElseIf row(1) = "W" Or row(1) = "WIND" Then
                row(1) = "WIND"
            Else
                row(1) = "OTHER"
            End If
            ''''Module
            '''''''''' write whole in if count is > 0
            If dtNODELOAD_arrange.Rows.Count() > 1 Then
                Dim onetimecheck As Integer = 0
                For Each row2 As DataRow In dtNODELOAD_arrange.Rows
                    If onetimecheck = 0 Then
                        out_file.WriteLine("*CONLOAD") ' pointload
                        onetimecheck = 1
                    End If
                    If row2(7) = row(0) Then 'row(1)=D ie DEAD  
                        out_file.WriteLine(row2(0) & "," & row2(1) & "," & row2(2) & "," & row2(3) & "," & row2(4) & "," & row2(5) & "," & row2(6)) ' ask one in SAFE is -1
                    End If
                Next
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''Nodal displacement Load
            If dtPOINTDISPLOAD_arrange.Rows.Count() > 1 Then
                Dim onetimecheck As Integer = 0
                For Each row2 As DataRow In dtPOINTDISPLOAD_arrange.Rows
                    If onetimecheck = 0 Then
                        out_file.WriteLine("*SPDISP") ' pointload
                        onetimecheck = 1
                    End If
                    If row2(8) = row(0) Then 'row(1)=D ie DEAD  
                        out_file.WriteLine(row2(0) & "," & row2(1) & "," & row2(2) & "," & row2(3) & "," & row2(4) & "," & row2(5) & "," & row2(6) & "," & row2(7)) ' ask one in SAFE is -1
                    End If
                Next
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''' 
            ' *BEAMLOAD
            If dtBEAMLOAD_arrange.Rows.Count() > 1 Then
                Dim onetimecheck As Integer = 0
                For Each row2 As DataRow In dtBEAMLOAD_arrange.Rows
                    If onetimecheck = 0 Then
                        out_file.WriteLine("*BEAMLOAD") ' pointload
                        onetimecheck = 1
                    End If
                    If row2("REFERENCE") = row(0) Then 'row(1)=D ie DEAD  
                        out_file.WriteLine(row2(0) & "," & row2(1) & "," & row2(2) & "," & row2(3) & "," & row2(4) & " " & row2(5) & "," & row2(6) & "," & row2(7) & "," & row2(8) & "," & row2(9)) ' ask one in SAFE is -1
                    End If
                Next
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If dtPRESSURE_arrange_RA.Rows.Count() > 1 Then
                Dim onetimecheck As Integer = 0
                For Each row2 As DataRow In dtPRESSURE_arrange_RA.Rows
                    If row2(9) = row(0) Then 'row(1)=D ie DEAD  
                        If onetimecheck = 0 Then
                            out_file.WriteLine("*PRESSURE")
                            onetimecheck = 1
                        End If
                        out_file.WriteLine(row2(0) & "," & row2(1) & "," & row2(2) & "," & row2(3) & "," & row2(4) & "," & row2(5) & "," & row2(6) & "," & row2(7) & "," & row2(8))
                    End If
                Next
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Next
    End Function
    Public Function writing_loadpattern(ByVal out_file As StreamWriter)
        If dtload_pattern.Rows.Count > 0 Then
            out_file.WriteLine("*STLDCASE")
            For Each row As DataRow In dtload_pattern.Rows
                out_file.WriteLine(row("Pattern_name") & ", " & row("Pattern_type") & ",")
            Next
        End If
    End Function

    Public Function writing_loadpattern_SAFE(ByVal out_file As StreamWriter)
        If dtSTLDCASE_arrange.Rows.Count > 0 Then
            out_file.WriteLine("*STLDCASE")
            For Each row As DataRow In dtSTLDCASE_arrange.Rows
                out_file.WriteLine(row("LCNAME") & ", " & row("LCTYPE") & "," & row("DESC"))
            Next
        End If
    End Function
    Public Function writing_thickness(ByVal out_file As StreamWriter)
        If dtthickness.Rows.Count > 0 Then
            out_file.WriteLine("*THICKNESS")
            For Each row As DataRow In dtthickness.Rows
                out_file.WriteLine(row("Thickness_id") & ", VALUE, YES, " & row("Thickness_depth") & ", 0, NO, 0, 0")
            Next
        End If
    End Function


    Public Function writing_thickness_SAFE(ByVal out_file As StreamWriter)
        If dtTHICKNESS_arrange.Rows.Count > 0 Then
            out_file.WriteLine("*THICKNESS")
            For Each row As DataRow In dtTHICKNESS_arrange.Rows
                out_file.WriteLine(row("iTHK") & "," & row("TYPE") & "," & row("bSAME") & "," & row("THIK-IN") & _
                                   "," & row("THIK-OUT") & "," & row("bOFFSET") & "," & row("OFFTYPE"))
            Next
        End If
    End Function

    Public Function writing_modifier(ByVal out_file As StreamWriter)
        If dtmodifier.Rows.Count > 0 Then
            out_file.WriteLine("*SECT-SCALE")
            For i = 0 To dtmodifier.Rows.Count - 1
                out_file.WriteLine(dtmodifier.Rows(i).Item("mod_id") & ", " & dtmodifier.Rows(i).Item("amod") & ", " & dtmodifier.Rows(i).Item("a2mod") & ", " & dtmodifier.Rows(i).Item("a3mod") & ", " & dtmodifier.Rows(i).Item("jmod") & ", " & dtmodifier.Rows(i).Item("i2mod") & ", " & dtmodifier.Rows(i).Item("i3mod") & ", " & dtmodifier.Rows(i).Item("wmod") & ", , 1")
            Next
        End If
    End Function

    Public Function writting_spring(ByVal out_file As StreamWriter)
        If dt_springs.Rows.Count > 0 Then
            out_file.WriteLine("*SPRING")
            For i = 0 To dt_springs.Rows.Count - 1
                out_file.WriteLine(dt_springs.Rows(i).Item("Sp_node") & ", LINEAR, " & dt_springs.Rows(i).Item("Sp_ux") & ", " & dt_springs.Rows(i).Item("Sp_uy") & ", " & dt_springs.Rows(i).Item("Sp_uz") & ", " & dt_springs.Rows(i).Item("Sp_rx") & ", " & dt_springs.Rows(i).Item("Sp_ry") & ", " & dt_springs.Rows(i).Item("Sp_rz") & ", NO, 0, 0, 0, 0, 0, 0, , 0, 0, 0, 0, 0")
            Next
        End If
    End Function


    Public Function writting_spring_SAFE(ByVal out_file As StreamWriter)
        'Point SPRING
        If dtSPRINGPOINT_arrange.Rows.Count > 0 Then
            out_file.WriteLine("*SPRING")
            For Each row In dtSPRINGPOINT_arrange.Rows
                out_file.WriteLine(row("NODE_LIST") & ", " & row("Type") & ", " & row("SDx") & ", " & row("SDy") & ", " & row("SDz") & ", " & row("SRx") & ", " & row("SRy") & ", " & row("SRz") & ", " & row("GROUP"))
            Next
        End If
        'SURFACE SPRING
        If dtSURFACESPRING_arrange_RA.Rows.Count > 0 Then
            out_file.WriteLine("*SURFACE-SPRING ")
            For Each row In dtSURFACESPRING_arrange_RA.Rows
                out_file.WriteLine(row("ELEM_LIST") & ", " & row("Type") & ", " & row("iDIR") & ", " & row("WIDTH") & ", " & row("iSPR-TYPE") & ", " & row("MODULUSP") & ", " & row("GROUP"))
            Next
        End If

    End Function

    'Public Function writing_floadtype(ByVal out_file As StreamWriter)
    '    If dt_area_load_etabs.Rows.Count > 0 Then
    '        out_file.WriteLine(" ")
    '        out_file.WriteLine("*PRESSURE")
    '        For n_area_etabs = 0 To dt_area_load_etabs.Rows.Count - 1
    '            Dim neg_chk As Integer = 0
    '            For n_area_ele = final_plate_count_start - 1 To dt_final_element_list.Rows.Count - 1
    '                If CStr(dt_area_load_etabs.Rows(n_area_etabs).Item("Area_name") & "_" & dt_area_load_etabs.Rows(n_area_etabs).Item("Area_story")) = CStr(dt_final_element_list.Rows(n_area_ele).Item("Final_org_name") & "_" & dt_final_element_list.Rows(n_area_ele).Item("Final_org_story")) Then
    '                    Dim lc_dir As String = dt_area_load_etabs.Rows(n_area_etabs).Item("Area_dir")
    '                    If lc_dir = "GRAV" Then
    '                        lc_dir = "GZ"
    '                        neg_chk = 1
    '                    End If
    '                    If lc_dir = "XPROJ" Then
    '                        lc_dir = "GX"
    '                    End If
    '                    If lc_dir = "YPROJ" Then
    '                        lc_dir = "GY"
    '                    End If
    '                    If lc_dir = "GRAVPROJ" Then
    '                        lc_dir = "GZ"
    '                        neg_chk = 1
    '                    End If
    '                    If lc_dir = "1" Then
    '                        lc_dir = "LX"
    '                    End If
    '                    If lc_dir = "2" Then
    '                        lc_dir = "LY"
    '                    End If
    '                    If lc_dir = "3" Then
    '                        lc_dir = "LZ"
    '                    End If
    '                    If lc_dir = "X" Then
    '                        lc_dir = "GX"
    '                    End If
    '                    If lc_dir = "Y" Then
    '                        lc_dir = "GY"
    '                    End If
    '                    If neg_chk = 0 Then
    '                        out_file.WriteLine(dt_final_element_list.Rows(n_area_ele).Item("Final_reference") & ", PRES, PLATE, FACE, " & dt_area_load_etabs.Rows(n_area_etabs).Item("Area_dir") & ", 0, 0, 0, NO," & dt_area_load_etabs.Rows(n_area_etabs).Item("Area_load_mag") & ", 0, 0, 0, 0,")
    '                    End If
    '                    If neg_chk = 1 Then
    '                        out_file.WriteLine(dt_final_element_list.Rows(n_area_ele).Item("Final_reference") & ", PRES, PLATE, FACE, " & dt_area_load_etabs.Rows(n_area_etabs).Item("Area_dir") & ", 0, 0, 0, NO, -" & dt_area_load_etabs.Rows(n_area_etabs).Item("Area_load_mag") & ", 0, 0, 0, 0,")
    '                    End If
    '                End If
    '            Next n_area_ele
    '        Next n_area_etabs
    '    End If
    'End Function

    'Public Function writing_floorload(ByVal out_file As StreamWriter)
    '    If dt_areaload_pass.Rows.Count > 0 Then
    '        out_file.WriteLine(" ")
    '        out_file.WriteLine("*FLOORLOAD")
    '        For Each row As DataRow In dt_areaload_pass.Rows
    '            If row("Area_pass_n4") <> 0 Then
    '                out_file.WriteLine("   " & row("Area_pass_name") & ", 2, 0, 0, 0, 0, " & row("Area_pass_dir") & ", NO, , NO, NO, , " & row("Area_pass_n1") & ", " & row("Area_pass_n2") & ", " & row("Area_pass_n3") & ", " & row("Area_pass_n4"))
    '            Else
    '                out_file.WriteLine("   " & row("Area_pass_name") & ", 2, 0, 0, 0, 0, " & row("Area_pass_dir") & ", NO, , NO, NO, , " & row("Area_pass_n1") & ", " & row("Area_pass_n2") & ", " & row("Area_pass_n3"))
    '            End If

    '        Next
    '    End If
    'End Function

    Public Function rearrange_elem()

        Dim N1 As Integer
        Dim N2 As Integer
        Dim lineassign_count As Integer = dtcrtdlineassign.Rows.Count - 1
        Dim elemconn_count As Integer = dtCrtdElem_conn.Rows.Count - 1
        Dim story_count As Integer = dtStorydata.Rows.Count - 1

        For nthbeam = 0 To lineassign_count
            For nthbeam1 = 0 To elemconn_count
                If dtCrtdElem_conn.Rows(nthbeam1).Item("Type") = dtcrtdlineassign.Rows(nthbeam).Item("la_uq_elem") Then
                    If dtCrtdElem_conn.Rows(CStr(nthbeam1)).Item("Floor_var") = "0" Then
                        N1 = func_node_converter(dtCrtdElem_conn.Rows(CStr(nthbeam1)).Item("N1"), dtcrtdlineassign(nthbeam).Item("la_story"))
                        N2 = func_node_converter(dtCrtdElem_conn.Rows(CStr(nthbeam1)).Item("N2"), dtcrtdlineassign(nthbeam).Item("la_story"))
                        Exit For
                    End If
                    If dtCrtdElem_conn.Rows(CStr(nthbeam1)).Item("Floor_var") <> "0" Then
                        For nthbeam2 = 0 To story_count
                            If dtcrtdlineassign(nthbeam).Item("la_story") = dtStorydata.Rows(nthbeam2).Item("Story_name") Then
                                N1 = func_node_converter(dtCrtdElem_conn.Rows(CStr(nthbeam1)).Item("N1"), dtStorydata.Rows(nthbeam2 - dtCrtdElem_conn.Rows(CStr(nthbeam1)).Item("Floor_var")).Item("Story_name"))
                                N2 = func_node_converter(dtCrtdElem_conn.Rows(CStr(nthbeam1)).Item("N2"), dtcrtdlineassign(nthbeam).Item("la_story"))
                                Application.DoEvents()
                                Exit For
                            End If
                            Application.DoEvents()
                        Next nthbeam2
                    End If
                End If
                Application.DoEvents()
            Next nthbeam1
            If N1 <> N2 And N1 <> 0 And N2 <> 0 Then
                dtCrtdElem.Rows.Add(CStr(nthbeam + 1), CStr(dtcrtdlineassign.Rows(CStr(nthbeam)).Item("la_uq_elem")), CStr(dtcrtdlineassign.Rows(CStr(nthbeam)).Item("la_section")), 0, N1, N2, CStr(dtcrtdlineassign.Rows(CStr(nthbeam)).Item("la_story")))
                area_element_count_begin = nthbeam + 1
            End If
            Application.DoEvents()
        Next nthbeam

    End Function

    Public Function rearrange_story(ByVal dtcrtdstoryorg As DataTable)
        Dim nthstory As Integer
        Dim pbval As Integer = 0
        story_height_sum = 0
        nthstory = dtcrtdstoryorg.Rows.Count - 1

        For Each row As DataRow In dtcrtdstoryorg.Rows
            If nthstory >= 0 Then
                story_height_sum = story_height_sum + dtcrtdstoryorg.Rows(nthstory).Item("Story_height")
                dtStorydata.Rows.Add(dtcrtdstoryorg.Rows(nthstory).Item("Story_name"), story_height_sum) ''breaking id therer is a space in between the stgory names
            End If
            nthstory = nthstory - 1
            pbval = pbval + 1
            Application.DoEvents()
        Next
    End Function

    Public Function elem_section()
        Dim n As Integer = 0
        Dim n1 As Integer
        Dim n2 As Integer
        Dim sec_chk As Integer = 0
        'MessageBox.Show("CrtdElem : " & dtCrtdElem.Rows.Count())
        'MessageBox.Show("dtProSection : " & dtProSection.Rows.Count())

        For Each row As DataRow In dtCrtdElem.Rows
            n1 = 0
            sec_chk = 0
            For Each row1 As DataRow In dtProSection.Rows
                If dtCrtdElem.Rows(n).Item("Section") = dtProSection.Rows(n1).Item("Section_name") Then
                    dtCrtdElem.Rows(n).Item("Section") = dtProSection.Rows(n1).Item("Section_id")
                    sec_chk = 1
                    n2 = 0
                    For Each row3 As DataRow In dtMatgrade.Rows
                        If dtMatgrade.Rows(n2).Item("Material_name") = dtProSection.Rows(n1).Item("Section_mat") Then
                            dtCrtdElem.Rows(n).Item("Material") = dtMatgrade.Rows(n2).Item("Material_id")
                            Application.DoEvents()
                            Exit For
                        End If
                        n2 = n2 + 1
                        Application.DoEvents()
                    Next
                    Exit For
                End If
                n1 = n1 + 1
            Next

            If sec_chk = 0 Then
                'Section could not be found
                'search Datatable again
                Dim strNF As String = row.Item("Section").ToString
                Dim nf() As DataRow = dtProSectionUndef.Select("Section_name = '" & strNF & "'")
                If nf.Count > 0 Then

                    dtCrtdElem.Rows(n).Item("Section") = CInt(nf(0)(0))

                    If dtCrtdElem.Rows(n).Item("Material") = 0 Then
                        Dim matnf As String = nf(0)("Section_mat").ToString
                        Dim nfmat() As DataRow = dtMatgrade.Select("Material_name = '" & matnf & "'")
                        If nfmat.Count > 0 Then
                            dtCrtdElem.Rows(n).Item("Material") = nfmat(0)
                        End If
                    End If
                Else
                    dtCrtdElem.Rows(n).Item("Section") = 1
                End If
            End If

            If dtCrtdElem.Rows(n).Item("Material") = "0" Then
                '     MessageBox.Show(dtCrtdElem.Rows(n).Item("Material"))
                dtCrtdElem.Rows(n).Item("Material") = 1
            End If
            n = n + 1

            Application.DoEvents()
        Next
    End Function

    Public Function area_element()
        Dim st As String = 0
        Dim t_mat_c As Integer = 0
        Dim t_sec_c As Integer = 0
        Dim N1_pass As Integer = 0
        Dim N2_pass As Integer = 0
        Dim N3_pass As Integer = 0
        Dim N4_pass As Integer = 0

        For n_main = 0 To dtarea_assign.Rows.Count - 1
            For n1 = 0 To dtarea_conn.Rows.Count - 1
                If dtarea_assign.Rows(n_main).Item("Area_name") = dtarea_conn.Rows(n1).Item("Connectivity_name") Then
                    Dim flr_var() As String = dtarea_conn.Rows(n1).Item("Connectivity_floor_chk").Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries) 'remember deleteing it after loop
                    If flr_var(0) <> 0 Then
                        For nthbeam2 = 0 To storydata_count
                            If dtarea_assign.Rows(n_main).Item("Area_story") = dtStorydata.Rows(nthbeam2).Item("Story_name") Then
                                N1_pass = func_node_converter(dtarea_conn.Rows(n1).Item("N1"), dtStorydata.Rows(nthbeam2 - flr_var(0)).Item("Story_name"))
                                Exit For
                            End If
                        Next nthbeam2
                    End If
                    If flr_var(0) = 0 Then
                        N1_pass = func_node_converter(dtarea_conn.Rows(n1).Item("N1"), dtarea_assign.Rows(n_main).Item("Area_story"))
                    End If

                    If flr_var(1) <> 0 Then
                        For nthbeam2 = 0 To storydata_count
                            If dtarea_assign.Rows(n_main).Item("Area_story") = dtStorydata.Rows(nthbeam2).Item("Story_name") Then
                                N2_pass = func_node_converter(dtarea_conn.Rows(n1).Item("N2"), dtStorydata.Rows(nthbeam2 - flr_var(1)).Item("Story_name"))
                                Exit For
                            End If
                        Next nthbeam2
                    End If
                    If flr_var(1) = 0 Then
                        N2_pass = func_node_converter(dtarea_conn.Rows(n1).Item("N2"), dtarea_assign.Rows(n_main).Item("Area_story"))
                    End If

                    If flr_var(2) <> 0 Then
                        For nthbeam2 = 0 To storydata_count
                            If dtarea_assign.Rows(n_main).Item("Area_story") = dtStorydata.Rows(nthbeam2).Item("Story_name") Then
                                N3_pass = func_node_converter(dtarea_conn.Rows(n1).Item("N3"), dtStorydata.Rows(nthbeam2 - flr_var(2)).Item("Story_name"))
                                Exit For
                            End If
                        Next nthbeam2
                    End If
                    If flr_var(2) = 0 Then
                        N3_pass = func_node_converter(dtarea_conn.Rows(n1).Item("N3"), dtarea_assign.Rows(n_main).Item("Area_story"))
                    End If

                    If dtarea_conn.Rows(n1).Item("N4") <> "0" Then
                        If flr_var(3) <> 0 Then
                            For nthbeam2 = 0 To storydata_count
                                If dtarea_assign.Rows(n_main).Item("Area_story") = dtStorydata.Rows(nthbeam2).Item("Story_name") Then
                                    N4_pass = func_node_converter(dtarea_conn.Rows(n1).Item("N4"), dtStorydata.Rows(nthbeam2 - flr_var(3)).Item("Story_name"))
                                    Exit For
                                End If
                            Next nthbeam2
                        End If
                        If flr_var(3) = 0 Then
                            N4_pass = func_node_converter(dtarea_conn.Rows(n1).Item("N4"), dtarea_assign.Rows(n_main).Item("Area_story"))
                        End If
                    Else
                        N4_pass = 0
                    End If

                    t_sec_c = 0
                    Dim area_mat As String = "1"
                    Dim area_pro As String = "1"
                    For Each row5 As DataRow In dtthickness.Rows
                        If dtarea_assign.Rows(n_main).Item("Area_section") = dtthickness.Rows(t_sec_c).Item("Thickness_name") Then
                            area_pro = dtthickness.Rows(t_sec_c).Item("Thickness_id")
                            t_mat_c = 0
                            For Each row6 As DataRow In dtMatgrade.Rows
                                If dtMatgrade.Rows(t_mat_c).Item("Material_name") = dtthickness.Rows(t_sec_c).Item("Thickness_material") Then
                                    area_mat = dtMatgrade.Rows(t_mat_c).Item("Material_id")
                                    Application.DoEvents()
                                    Exit For
                                End If
                                t_mat_c = t_mat_c + 1
                                Application.DoEvents()
                            Next
                            Exit For
                        End If
                        t_sec_c = t_sec_c + 1
                        Application.DoEvents()
                    Next
                    If N1_pass <> 0 And N2_pass <> 0 And N3_pass <> 0 And N1_pass <> N2_pass And N1_pass <> N3_pass And N1_pass <> N4_pass And N2_pass <> N3_pass And N2_pass <> N4_pass And N3_pass <> N4_pass Then
                        dtarea_ele_pass.Rows.Add(dtarea_conn.Rows(n1).Item("Connectivity_count"), area_mat, area_pro, N1_pass, N2_pass, N3_pass, N4_pass, dtarea_conn.Rows(n1).Item("SUB"), dtarea_conn.Rows(n1).Item("WID"), dtarea_assign.Rows(n_main).Item("Area_name"), dtarea_assign.Rows(n_main).Item("Area_story"), dtarea_conn.Rows(n1).Item("chker"))
                        Application.DoEvents()
                    End If
                End If
                Application.DoEvents()
            Next n1
            Application.DoEvents()
        Next n_main
    End Function

    'Public Function areaload_floorload()
    '    Dim n As Integer = 0
    '    Dim n1 As Integer = 0
    '    Dim lc_dir As String

    '    For Each row As DataRow In dt_area_load_type.Rows
    '        n1 = 0
    '        For Each row2 As DataRow In dtarea_ele_pass.Rows
    '            If dtarea_ele_pass.Rows(n1).Item("Orignal_area_name") = dt_area_load_type.Rows(n).Item("Loadcase_name_area") And dtarea_ele_pass.Rows(n1).Item("Orignal_area_story") = dt_area_load_type.Rows(n).Item("Loadcase_name_story") Then
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "GRAV" Then
    '                    lc_dir = "GZ"
    '                End If
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "XPROJ" Then
    '                    lc_dir = "GX"
    '                End If
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "YPROJ" Then
    '                    lc_dir = "GY"
    '                End If
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "GRAVPROJ" Then
    '                    lc_dir = "GZ"
    '                End If
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "1" Then
    '                    lc_dir = "LX"                             'check again once
    '                End If                                        'check again once
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "2" Then
    '                    lc_dir = "LY"                             'check again once
    '                End If                                        'check again once
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "3" Then
    '                    lc_dir = "LZ"                             'check again once
    '                End If                                        'check again once
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "X" Then
    '                    lc_dir = "GX"                             'check again once
    '                End If                                        'check again once
    '                If dt_area_load_type.Rows(n).Item("Loadcase_name_dir") = "Y" Then
    '                    lc_dir = "GY"                             'check again once
    '                End If
    '                If dtarea_ele_pass.Rows(n1).Item("chker") = 1 Then
    '                    dt_areaload_pass.Rows.Add(dt_area_load_type.Rows(n).Item("Loadcase_name"), lc_dir, dtarea_ele_pass.Rows(n1).Item("N1"), dtarea_ele_pass.Rows(n1).Item("N2"), dtarea_ele_pass.Rows(n1).Item("N3"), dtarea_ele_pass.Rows(n1).Item("N4"))
    '                End If
    '            End If
    '            n1 = n1 + 1
    '        Next
    '        n = n + 1
    '    Next
    'End Function

    Public Function func_node_converter(ByVal input_node As String, ByVal input_story As String)

        Dim n_node_p As Integer = 0
        Dim fnd As Integer = 0
        Dim st_point As Integer
        For n1 = 0 To storydata_count
            If dtStorydata.Rows(n1).Item("Story_name") = input_story Then
                st_point = n1 * tot_org_nodes
                Exit For
            End If
            Application.DoEvents()
        Next n1
        For n_node = st_point To node_count_infunc
            If input_node = dtCrtdNode.Rows(n_node).Item("Node_orignal") And input_story = dtCrtdNode.Rows(n_node).Item("Story_orignal") Then
                dtCrtdNode.Rows(n_node).Item("IS_PASSING") = 1
                n_node_p = n_node
                fnd = 1
                Application.DoEvents()
                Exit For
            End If
            Application.DoEvents()
        Next n_node
        If fnd = 1 Then
            Return (dtCrtdNode.Rows(n_node_p).Item("Node_Number"))
        Else
            Return (0)
        End If
        Application.DoEvents()
    End Function

    Public Function func_element_converter(ByVal input_type As String, ByVal input_story As String)

        Dim n_ele_p As Integer = 0
        Dim fnd As Integer = 0
        For n_ele = 0 To dtCrtdElem.Rows.Count - 1
            If input_type = dtCrtdElem.Rows(n_ele).Item("Type") And input_story = dtCrtdElem.Rows(n_ele).Item("Floor_var") Then
                n_ele_p = n_ele
                fnd = 1
                Exit For
            End If
        Next n_ele
        If fnd = 1 Then
            Return (dtCrtdElem.Rows(n_ele_p).Item("Element_Number"))
        Else
            Return (0)
        End If
        Application.DoEvents()
    End Function

    Public Function straight_line_check(ByVal node_coll() As String)
        If node_coll.Count > 0 Then
            For l1 = 0 To dtCrtdNode.Rows.Count - 1
                If node_coll(0) = dtCrtdNode.Rows(l1).Item("Node_Number") Then
                    For l2 = 0 To dtCrtdNode.Rows.Count - 1
                        If node_coll(1) = dtCrtdNode.Rows(l2).Item("Node_Number") Then
                            If dtCrtdNode.Rows(l1).Item("X") = dtCrtdNode.Rows(l2).Item("X") Or dtCrtdNode.Rows(l1).Item("Y") = dtCrtdNode.Rows(l2).Item("Y") Or dtCrtdNode.Rows(l1).Item("Z") = dtCrtdNode.Rows(l2).Item("Z") Then
                                Return 0
                            End If
                        End If
                        If node_coll(2) = dtCrtdNode.Rows(l2).Item("Node_Number") Then
                            If dtCrtdNode.Rows(l1).Item("X") = dtCrtdNode.Rows(l2).Item("X") Or dtCrtdNode.Rows(l1).Item("Y") = dtCrtdNode.Rows(l2).Item("Y") Or dtCrtdNode.Rows(l1).Item("Z") = dtCrtdNode.Rows(l2).Item("Z") Then
                                Return 0
                            End If
                        End If
                    Next
                End If
            Next
            Return 1
        End If
    End Function

    Private Sub path_disp_Click(sender As Object, e As EventArgs) Handles path_disp.Click
        OpenFileDialog.Title = "Enter the input file"
        OpenFileDialog.Filter = "ETABS Text Files (*.$et, *e2k)|*.$et;*.e2k|All Files (*.*)|*.*"
        OpenFileDialog.ShowDialog()
        file_name = OpenFileDialog.FileName()
        If file_name <> "NO_FILE_SELECTED" Then
            path_disp.Text = file_name
            in_path = Path.GetDirectoryName(file_name)
            only_file_name = Path.GetFileNameWithoutExtension(file_name)
            lines = File.ReadAllLines(file_name)
            nodenumber = 1
            elementnumber = 1
        End If
        Application.DoEvents()
    End Sub

    Public Function delete_db()

        dtCrtdUnits.Columns.Clear()
        dtCrtdUnits.Rows.Clear()

        dtCrtdNode.Columns.Clear()
        dtCrtdNode.Rows.Clear()

        dtCrtdElem_conn.Columns.Clear()
        dtCrtdElem_conn.Rows.Clear()

        dtCrtdElem.Columns.Clear()
        dtCrtdElem.Rows.Clear()

        dtcrtdnodeorg.Columns.Clear()
        dtcrtdnodeorg.Rows.Clear()

        dtcrtdlineassign.Columns.Clear()
        dtcrtdlineassign.Rows.Clear()

        dtcrtdstoryorg.Columns.Clear()
        dtcrtdstoryorg.Rows.Clear()

        dtStorydata.Columns.Clear()
        dtStorydata.Rows.Clear()

        dtpointassign.Columns.Clear()
        dtpointassign.Rows.Clear()

        dtboundary_conditions.Columns.Clear()
        dtboundary_conditions.Rows.Clear()

        dtMatgrade.Columns.Clear()
        dtMatgrade.Rows.Clear()

        dtProSection.Columns.Clear()
        dtProSection.Rows.Clear()

        dtProSectionUndef.Columns.Clear()
        dtProSectionUndef.Rows.Clear()

        dtload_pattern.Columns.Clear()
        dtload_pattern.Rows.Clear()

        dtNodalLoads.Columns.Clear()
        dtNodalLoads.Rows.Clear()

        dtbeam_loads.Columns.Clear()
        dtbeam_loads.Rows.Clear()

        dtarea_assign.Columns.Clear()
        dtarea_assign.Rows.Clear()

        dtarea_conn.Columns.Clear()
        dtarea_conn.Rows.Clear()

        dtthickness.Columns.Clear()
        dtthickness.Rows.Clear()

        dtarea_ele_pass.Columns.Clear()
        dtarea_ele_pass.Rows.Clear()

        dt_area_load_etabs.Columns.Clear()
        dt_area_load_etabs.Rows.Clear()

        dt_area_load_type.Columns.Clear()
        dt_area_load_type.Rows.Clear()

        dt_areaload_pass.Columns.Clear()
        dt_areaload_pass.Rows.Clear()

        dt_final_element_list.Columns.Clear()
        dt_final_element_list.Rows.Clear()

        dt_loadset.Columns.Clear()
        dt_loadset.Rows.Clear()

        dtmodifier.Columns.Clear()
        dtmodifier.Rows.Clear()

        dt_pointspring.Columns.Clear()
        dt_pointspring.Rows.Clear()

        dt_springs.Columns.Clear()
        dt_springs.Rows.Clear()

        ProgressBar_read.Value = 0
        ProgressBar_writing.Value = 0

        Application.DoEvents()
    End Function
    Public Function delete_db_SAFE()

        dtPCunits_read.Columns.Clear()
        dtPCunits_read.Rows.Clear()

        dtOGPC_read.Columns.Clear()
        dtOGPC_read.Rows.Clear()

        dtOGL_read.Columns.Clear()
        dtOGL_read.Rows.Clear()

        dtOGA_read.Columns.Clear()
        dtOGA_read.Rows.Clear()

        dtOGDS_read.Columns.Clear()
        dtOGDS_read.Rows.Clear()

        dtMPG_read.Columns.Clear()
        dtMPG_read.Rows.Clear()

        dtMPS_read.Columns.Clear()
        dtMPS_read.Rows.Clear()

        dtMPC_read.Columns.Clear()
        dtMPC_read.Rows.Clear()

        dtMPR_read.Columns.Clear()
        dtMPR_read.Rows.Clear()

        dtMPT_read.Columns.Clear()
        dtMPT_read.Rows.Clear()

        dtMPO_read.Columns.Clear()
        dtMPO_read.Rows.Clear()

        dtSPG_read.Columns.Clear()
        dtSPG_read.Rows.Clear()

        dtSPSS_read.Columns.Clear()
        dtSPSS_read.Rows.Clear()

        dtSPRW_read.Columns.Clear()
        dtSPRW_read.Rows.Clear()

        dtSP_read.Columns.Clear()
        dtSP_read.Rows.Clear()

        dtSPL_read.Columns.Clear()
        dtSPL_read.Rows.Clear()

        dtSPP_read.Columns.Clear()
        dtSPP_read.Rows.Clear()

        dtBPG_read.Columns.Clear()
        dtBPG_read.Rows.Clear()

        dtBPRB_read.Columns.Clear()
        dtBPRB_read.Rows.Clear()

        dtCPG_read.Columns.Clear()
        dtCPG_read.Rows.Clear()

        dtCPR_read.Columns.Clear()
        dtCPR_read.Rows.Clear()

        dtWP_read.Columns.Clear()
        dtWP_read.Rows.Clear()

        dtLP_read.Columns.Clear()
        dtLP_read.Rows.Clear()

        dtLCG_read.Columns.Clear()
        dtLCG_read.Rows.Clear()

        dtLCS_read.Columns.Clear()
        dtLCS_read.Rows.Clear()

        dtLCLA_read.Columns.Clear()
        dtLCLA_read.Rows.Clear()

        dtLC_read.Columns.Clear()
        dtLC_read.Rows.Clear()

        dtSPA_read.Columns.Clear()
        dtSPA_read.Rows.Clear()

        dtBPA_read.Columns.Clear()
        dtBPA_read.Rows.Clear()

        dtBIP_read.Columns.Clear()
        dtBIP_read.Rows.Clear()

        dtCPA_read.Columns.Clear()
        dtCPA_read.Rows.Clear()

        dtCLA_read.Columns.Clear()
        dtCLA_read.Rows.Clear()

        dtCIP_read.Columns.Clear()
        dtCIP_read.Rows.Clear()

        dtWPA_read.Columns.Clear()
        dtWPA_read.Rows.Clear()

        dtPRA_read.Columns.Clear()
        dtPRA_read.Rows.Clear()

        dtLASL_read.Columns.Clear()
        dtLASL_read.Rows.Clear()

        dtLAPL_read.Columns.Clear()
        dtLAPL_read.Rows.Clear()

        dtPSA_read.Columns.Clear()
        dtPSA_read.Rows.Clear()

        dtCPC_read.Columns.Clear()
        dtCPC_read.Rows.Clear()

        dtBPTB_read.Columns.Clear()
        dtBPTB_read.Rows.Clear()

        dtBPLB_read.Columns.Clear()
        dtBPLB_read.Rows.Clear()

        dtCPTS_read.Columns.Clear()
        dtCPTS_read.Rows.Clear()

        dtCPLS_read.Columns.Clear()
        dtCPLS_read.Rows.Clear()

        dtSoilA_read.Columns.Clear()
        dtSoilA_read.Rows.Clear()

        dtLSA_read.Columns.Clear()
        dtLSA_read.Rows.Clear()
        '''''''''''''''''''''''''''''''''''''''''''''''
        dtNODE_arrange.Columns.Clear()
        dtNODE_arrange.Rows.Clear()

        dtNODELOAD_arrange.Columns.Clear()
        dtNODELOAD_arrange.Rows.Clear()

        dtMATERIAL_arrange.Columns.Clear()
        dtMATERIAL_arrange.Rows.Clear()

        dtTHICKNESS_arrange.Columns.Clear()
        dtTHICKNESS_arrange.Rows.Clear()

        dtSPRINGPOINT_arrange.Columns.Clear()
        dtSPRINGPOINT_arrange.Rows.Clear()

        dtCONSTRAIN_arrange.Columns.Clear()
        dtCONSTRAIN_arrange.Rows.Clear()

        dtPRESSURE_arrange.Columns.Clear()
        dtPRESSURE_arrange.Rows.Clear()

        dtPRESSURE_arrange_RA.Columns.Clear()
        dtPRESSURE_arrange_RA.Rows.Clear()

        dtSTLDCASE_arrange.Columns.Clear()
        dtSTLDCASE_arrange.Rows.Clear()

        dtBEAM_arrange.Columns.Clear()
        dtBEAM_arrange.Rows.Clear()

        dtSECTION_arrange.Columns.Clear()
        dtSECTION_arrange.Rows.Clear()

        dtPLATE_arrange.Columns.Clear()
        dtPLATE_arrange.Rows.Clear()

        dtSURFACESPRING_arrange.Columns.Clear()
        dtSURFACESPRING_arrange.Rows.Clear()

        dtSURFACESPRING_arrange_RA.Columns.Clear()
        dtSURFACESPRING_arrange_RA.Rows.Clear()


        dtLALDL_read.Columns.Clear()
        dtLALDL_read.Rows.Clear()

        dtBEAMLOAD_arrange.Columns.Clear()
        dtBEAMLOAD_arrange.Rows.Clear()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        dtLAPD_read.Columns.Clear()
        dtLAPD_read.Rows.Clear()

        dtPOINTDISPLOAD_arrange.Columns.Clear()
        dtPOINTDISPLOAD_arrange.Rows.Clear()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ProgressBar_read.Value = 0
        ProgressBar_writing.Value = 0

        Application.DoEvents()
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        delete_db_SAFE()
        delete_db()
        End
        Application.Exit()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("Important Points to be noted :" _
                        & vbNewLine & " " _
                        & vbNewLine & "ETABS" _
                        & vbNewLine & "1. Story data needs to be generated by user for more accuracy." _
                        & vbNewLine & "2. Meshing Should be done wherever required" _
                        & vbNewLine & "3. If type of loading is not found in GEN it will be considered as live load" _
                        & vbNewLine & "4. Earthquake Loading and Wind Loading Should be generated as per requirement." _
                        & vbNewLine & "5. Sections whose dimensions are altered are represented with a '*' at end" _
                        & vbNewLine & "6. Only Standard Boundary Conditions are transfered others have to be given explicitly by the user. (It will be prompted if no boundary conditions are transfered)" _
                        & vbNewLine & "7. USer defined sections will only be transformed" _
                        & vbNewLine & " " _
                        & vbNewLine & "SAFE" _
                        & vbNewLine & "1. SAFE .f2k file Must generete from SAFE (FILE->EXPORT MODEL-> SAFE .F2K > Check All In Table  -> ClickOK -> SAVE .f2k |Open this file through Converter)" _
                        & vbNewLine & "2. Prefer SAFE 12 version to generate .f2k files and then convert f2k -> mgt" _
                        & vbNewLine & "3. Meshing Should be done wherever required" _
                        & vbNewLine & "4. If type of loading is not found in GEN it will be considered as other load" _
                        & vbNewLine & "5. Earthquake Loading and Wind Loading Should be generated as per requirement." _
                        & vbNewLine & "6. Only Standard Boundary Conditions are transfered others have to be given explicitly by the user. (It will be prompted if no boundary conditions are transfered)" _
                        & vbNewLine & "7. User defined sections will only be transformed" _
                        & vbNewLine & "8. If no Property/material assign in SAFE then MidasGen will defult assign ""None"" name property or 1 & 1 " _
                        & vbNewLine & "9. Cross Check for Surface Pressure Load Local axis" _
                        & vbNewLine & "10. WAFFLE AND RIBBED SLAB ASSUMED AS PLATED OF CONSTANT MIN SLAB DEPTH FROM SAFE,USER MUST INCLUDE FURTEHR PROPERTIES")
    End Sub

End Class


