<%@ Page Title="Registrar entrega"
    Language="VB"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="false"
    CodeBehind="RegistrarEntrega.aspx.vb"
    Inherits="AcopioWeb.RegistrarEntrega" %>

<asp:Content ID="Contenido"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h1 class="h3 mb-4">Registrar entrega</h1>

    <div class="card shadow-sm">
        <div class="card-body">

            <asp:ValidationSummary
                runat="server"
                ValidationGroup="Entrega"
                CssClass="alert alert-danger" />

            <div class="mb-3">
                <asp:Label runat="server"
                    AssociatedControlID="ddlProductor"
                    Text="Productor" />

                <asp:DropDownList ID="ddlProductor"
                    runat="server"
                    CssClass="form-select" />

                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="ddlProductor"
                    InitialValue=""
                    ValidationGroup="Entrega"
                    ErrorMessage="Seleccione un productor."
                    Display="None" />
            </div>

            <div class="mb-3">
                <asp:Label runat="server"
                    AssociatedControlID="txtBoleta"
                    Text="Número de boleta" />

                <asp:TextBox ID="txtBoleta"
                    runat="server"
                    MaxLength="8"
                    CssClass="form-control" />

                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="txtBoleta"
                    ValidationGroup="Entrega"
                    ErrorMessage="Ingrese la boleta."
                    Display="None" />

                <asp:RegularExpressionValidator
                    runat="server"
                    ControlToValidate="txtBoleta"
                    ValidationExpression="^B-[0-9]{6}$"
                    ValidationGroup="Entrega"
                    ErrorMessage="La boleta debe tener el formato B-000123."
                    Display="None" />

                <asp:CustomValidator ID="cvBoleta"
                    runat="server"
                    ControlToValidate="txtBoleta"
                    ValidationGroup="Entrega"
                    ClientValidationFunction="validarBoletaDisponible"
                    OnServerValidate="cvBoleta_ServerValidate"
                    ErrorMessage="La boleta ya está registrada."
                    Display="None" />
            </div>

            <div class="mb-3">
                <asp:Label runat="server"
                    AssociatedControlID="txtPeso"
                    Text="Peso neto en kg" />

                <asp:TextBox ID="txtPeso"
                    runat="server"
                    CssClass="form-control" />

                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="txtPeso"
                    ValidationGroup="Entrega"
                    ErrorMessage="Ingrese el peso."
                    Display="None" />

                <asp:RegularExpressionValidator
                    runat="server"
                    ControlToValidate="txtPeso"
                    ValidationExpression="^[0-9]+$"
                    ValidationGroup="Entrega"
                    ErrorMessage="El peso debe ser un número entero."
                    Display="None" />

                <asp:RangeValidator
                    runat="server"
                    ControlToValidate="txtPeso"
                    Type="Integer"
                    MinimumValue="100"
                    MaximumValue="30000"
                    ValidationGroup="Entrega"
                    ErrorMessage="El peso debe estar entre 100 y 30000 kg."
                    Display="None" />
            </div>

            <div class="mb-3">
                <asp:Label runat="server"
                    AssociatedControlID="ddlCalidad"
                    Text="Calidad" />

                <asp:DropDownList ID="ddlCalidad"
                    runat="server"
                    CssClass="form-select">

                    <asp:ListItem Text="Seleccione..."
                        Value="" />
                    <asp:ListItem Text="A — ₡95/kg"
                        Value="A" />
                    <asp:ListItem Text="B — ₡80/kg"
                        Value="B" />
                    <asp:ListItem Text="C — ₡60/kg"
                        Value="C" />

                </asp:DropDownList>

                <asp:RequiredFieldValidator
                    runat="server"
                    ControlToValidate="ddlCalidad"
                    InitialValue=""
                    ValidationGroup="Entrega"
                    ErrorMessage="Seleccione la calidad."
                    Display="None" />
            </div>

            <asp:Button ID="btnGuardar"
                runat="server"
                Text="Registrar entrega"
                ValidationGroup="Entrega"
                CssClass="btn btn-success"
                OnClick="btnGuardar_Click" />

            <asp:Label ID="lblMensaje"
                runat="server"
                EnableViewState="false" />

        </div>
    </div>

    <script type="text/javascript">
        function validarBoletaDisponible(source, args) {
            var boletas = window.boletasRegistradas || [];
            args.IsValid = boletas.indexOf(args.Value) === -1;
        }
    </script>

</asp:Content>
