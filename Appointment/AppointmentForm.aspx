<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AppointmentForm.aspx.cs" Inherits="Appointment.AppointmentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>APPOINTMENT</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="row mt-5">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <div class="card">
                        <div class="card-body">
                            <div class="ml-2">
                                <h4>Assign Appointment</h4>
                            </div>
                            <hr />
                            <br />
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Label1" runat="server" Text="Appointment Name"></asp:Label>
                                    <asp:TextBox Class="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="Label2" runat="server" Text="Parent Name"></asp:Label>
                                    <asp:DropDownList Class="form-control" ID="DropDownList1" DataTextField="APPOINTMENT_NAME" DataValueField="APPOINTMENT_ID" runat="server">
                                        <asp:ListItem Text="" Value="0">Select App.</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-3">
                                    <br />
                                    <asp:Button ID="Button1" class="btn btn-primary btn-sm" runat="server" Text="Insert" OnClick="Button1_Click" />
                                    <asp:Button ID="Button2" class="btn btn-success btn-sm" runat="server" Text="Clear" OnClick="Button1_Click2" />

                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <div class="col-sm-3">
                                    <asp:Label ID="Label3" runat="server" Text="Limit Month"></asp:Label>
                                    <asp:TextBox TextMode="Number" Class="form-control" ID="TextBox2" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Label ID="Label4" runat="server" Text="Limit Year"></asp:Label>
                                    <asp:TextBox TextMode="Number" Class="form-control" ID="TextBox3" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-sm-2"></div>
            </div>

            <div class="row mt-4">
                <div class="col-sm-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="ml-2">
                                <h4>Appointment Table</h4>
                            </div>
                            <hr />
                            <br />
                            <div class="row">
                                <div class="col-sm-12">
                                    <table id="tbl1" class="table table-bordered table-striped">
                                        <thead class="thead-dark">
                                            <tr>
                                                <th scope="col">App. Id</th>
                                                <th scope="col">App. Name</th>
                                                <th scope="col">Parent</th>
                                                <th scope="col">Limit Month</th>
                                                <th scope="col">Limit Year</th>
                                                <th scope="col">Status</th>
                                                <th scope="col">Created By</th>
                                                <th scope="col">Created Date</th>
                                                <th scope="col">Modified By</th>
                                                <th scope="col">Modified Date</th>
                                                <th scope="col">Update</th>
                                                <th scope="col">Delete</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <% =_str %>
                                        </tbody>
                                    </table>
                                    <button type="button" class="btn btn-danger m-1" onclick="exportTableToExcel('tbl1')">Download Table</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        function exportTableToExcel(tableID, filename = '') {
            var downloadLink;
            var dataType = 'application/vnd.ms-excel';
            var tableSelect = document.getElementById(tableID);
            var tableHTML = tableSelect.outerHTML.replace(/ /g, '%20');

            // Specify file name
            filename = filename ? filename + '.xls' : 'excel_data.xls';

            // Create download link element
            downloadLink = document.createElement("a");

            document.body.appendChild(downloadLink);

            if (navigator.msSaveOrOpenBlob) {
                var blob = new Blob(['\ufeff', tableHTML], {
                    type: dataType
                });
                navigator.msSaveOrOpenBlob(blob, filename);
            } else {
                // Create a link to the file
                downloadLink.href = 'data:' + dataType + ', ' + tableHTML;

                // Setting the file name
                downloadLink.download = filename;

                //triggering the function
                downloadLink.click();
            }

        }
    </script>

</body>
</html>
