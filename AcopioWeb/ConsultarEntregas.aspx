<%@ Page Title="Consultar entregas"
    Language="VB"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="false"
    CodeBehind="ConsultarEntregas.aspx.vb"
    Inherits="AcopioWeb.ConsultarEntregas" %>

<asp:Content ID="Contenido"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h1 class="h3 mb-3">Consultar entregas</h1>

    <asp:Label ID="lblAlcance"
        runat="server"
        CssClass="text-muted d-block mb-3" />

    <div class="table-responsive">

        <asp:GridView ID="gvEntregas"
            runat="server"
            AutoGenerateColumns="false"
            AllowPaging="true"
            PageSize="8"
            GridLines="None"
            CssClass="table table-striped table-bordered"
            EmptyDataText="No hay entregas para mostrar."
            OnPageIndexChanging="gvEntregas_PageIndexChanging">

            <Columns>

                <asp:BoundField
                    DataField="Boleta"
                    HeaderText="Boleta"
                    HtmlEncode="true" />

                <asp:BoundField
                    DataField="Productor"
                    HeaderText="Productor"
                    HtmlEncode="true" />

                <asp:BoundField
                    DataField="PesoKg"
                    HeaderText="Peso (kg)" />

                <asp:BoundField
                    DataField="Calidad"
                    HeaderText="Calidad"
                    HtmlEncode="true" />

                <asp:BoundField
                    DataField="Pago"
                    HeaderText="Pago"
                    DataFormatString="₡{0:N0}"
                    HtmlEncode="true" />

                <asp:BoundField
                    DataField="UsuarioCorreo"
                    HeaderText="Registrado por"
                    HtmlEncode="true" />

            </Columns>

            <PagerSettings Mode="Numeric" />
            <PagerStyle CssClass="text-center" />

        </asp:GridView>

    </div>

</asp:Content>
