
Partial Class _Default
    Inherits System.Web.UI.Page

    Dim fso = Server.CreateObject("Scripting.FileSystemObject")
    Dim dr = fso.Drives
    Dim fo = fso.GetFolder("C:\")
    Dim sfo = fo.SubFolders
    Dim fi
    Dim folderOfDrive
    Dim subfoldersOfFolder
    Dim filesOfFolder
    
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim drvLetter As String
        Dim spTotal As String
        Dim spAvailable As String
        Dim spFree As String
        Dim volName As String
        Dim row As TableRow

        For Each drv In dr

            If drv.DriveType = 2 Then

                row = New TableRow

                row.Cells.Add(New TableCell())
                row.Cells.Add(New TableCell())
                row.Cells.Add(New TableCell())
                row.Cells.Add(New TableCell())
                row.Cells.Add(New TableCell())

                drvLetter = drv.DriveLetter
                spTotal = drv.TotalSize
                spAvailable = drv.AvailableSpace
                spFree = drv.FreeSpace
                volName = drv.VolumeName

                row.Cells(0).Text = drvLetter
                row.Cells(0).Font.Bold = True
                row.Cells(0).BackColor = Drawing.Color.Blue
                row.Cells(0).ForeColor = Drawing.Color.White
                row.Cells(1).Text = spTotal
                row.Cells(2).Text = spAvailable
                row.Cells(3).Text = spFree
                row.Cells(4).Text = volName

                Table1.Rows.Add(row)

            End If

        Next

    End Sub

    Protected Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim str As String = ListBox1.SelectedItem.ToString()

        str = str & ":\"
        ListBox2.Items.Clear()

        fo = fso.GetFolder(str)
        sfo = fo.SubFolders

        For Each sf In sfo

            ListBox2.Items.Add(sf.Name)

        Next

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim i As Integer = 0
        Dim j As Integer = 0

        For Each drv In dr

            ListBox1.Items.Add(drv.DriveLetter)
            TreeView1.Nodes.Add(New TreeNode(drv.DriveLetter & ":"))

            If drv.DriveType = 2 Then

                fo = fso.GetFolder(drv.DriveLetter & ":\")
                sfo = fo.SubFolders
                j = 0

                For Each sf In sfo

                    TreeView1.Nodes(i).ChildNodes.Add(New TreeNode(sf.Name))
                    ListBox2.Items.Add(sf.Name)
                    folderOfDrive = fso.GetFolder(drv.DriveLetter & ":\" & sf.Name)

                    Try
                        subfoldersOfFolder = folderOfDrive.SubFolders

                        For Each sfof In subfoldersOfFolder

                            TreeView1.Nodes(i).ChildNodes(j).ChildNodes.Add(New TreeNode(sfof.Name))

                        Next

                        filesOfFolder = folderOfDrive.Files

                        For Each f In filesOfFolder

                            TreeView1.Nodes(i).ChildNodes(j).ChildNodes.Add(New TreeNode(f.Name))

                        Next

                    Catch ex As Exception

                    End Try

                    j += 1

                Next

                i += 1

            End If

        Next

    End Sub

    Protected Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged

        Dim str As String = ListBox1.SelectedItem.ToString()

        str = str & ":\"
        str = str & ListBox2.SelectedItem.ToString()

        ListBox3.Items.Clear()
        ListBox4.Items.Clear()

        fo = fso.GetFolder(str)
        sfo = fo.SubFolders

        For Each sf In sfo

            ListBox3.Items.Add(sf.Name)

        Next

        fi = fo.Files

        For Each f In fi

            ListBox4.Items.Add(f.Name)

        Next

    End Sub

    Protected Sub ListBox4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox4.SelectedIndexChanged

        Dim str As String = ListBox1.SelectedItem.ToString()

        str = str & ":\"
        str = str & ListBox2.SelectedItem.ToString()

        str = str & "\"
        str = str & ListBox4.SelectedItem.ToString()

        Dim ext = fso.GetExtensionName(str)

        If ext = "txt" Then

            Dim f = fso.OpenTextFile(str)
            TextBox1.Text = f.ReadAll

        Else

            TextBox1.Text = "Only Text files can be displayed.."

        End If
        
    End Sub

    Protected Sub TreeView1_SelectedNodeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView1.SelectedNodeChanged

        Dim str As String = TreeView1.SelectedNode.ValuePath

        str = str.Replace("/", "\")

        If TreeView1.SelectedNode.ChildNodes.Count = 0 Then

            Dim exist = fso.FileExists(str)

            If exist Then

                Dim ext = fso.GetExtensionName(str)

                If ext = "txt" Then

                    Dim f = fso.OpenTextFile(str)
                    TextBox2.Text = f.ReadAll

                Else

                    TextBox2.Text = "Only Text files can be displayed.."

                End If

            End If

        End If

    End Sub

End Class
