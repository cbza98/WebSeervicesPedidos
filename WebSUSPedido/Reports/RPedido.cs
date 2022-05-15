using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebSUSPedido.Models;

namespace WebSUSPedido.Reports
{
    public class RPedido
    {
        IWebHostEnvironment _oHostEnvironment;
        #region Atributos Clase
        int _maxColumn = 4;
        Document _document;
        PdfPTable _pdfPTable = new PdfPTable(4);
        PdfPCell _pdfPCell;
        Font _fontStyle;
        MemoryStream _memoryStream = new MemoryStream();
        List<Pedido> _pedidocab = new List<Pedido>();
        List<DPedidoV> _pedidobody = new List<DPedidoV>();

        #endregion

        #region Atributos de PDF
        PdfPTable Table = new PdfPTable(1);
        Font smallfont = FontFactory.GetFont("Arial", 7);
        Font largefont = FontFactory.GetFont("Arial", "16", false, 16, 1, BaseColor.Black);
        Font mediumfont = FontFactory.GetFont("Arial", "11", false, 11, 1, BaseColor.Black);
        Font mediumfontSN = FontFactory.GetFont("Arial", "11", false, 11, 0, BaseColor.Black);
        Font letraChica = FontFactory.GetFont("Arial", "8", false, 8, 0, BaseColor.Black);
        Font letraMuyChica = FontFactory.GetFont("Arial", "6", false, 6, 0, BaseColor.Black);
        Font letraChicaN = FontFactory.GetFont("Arial", "8", false, 8, 1, BaseColor.Black);
        Font smallnumericfont = FontFactory.GetFont("Arial", "6", true, 6, 2, BaseColor.Black);
        Font smallfontBlack = FontFactory.GetFont("Arial Black", 7);

        PdfPTable TableTitulo = new PdfPTable(1);
        PdfPTable TableCliente = new PdfPTable(4);
        PdfPTable TableItem = new PdfPTable(10);
        PdfPTable TableProducto = new PdfPTable(10);
        PdfPTable TableSubTotal = new PdfPTable(10);
        PdfPTable TableCondicion = new PdfPTable(10);
        PdfPTable TableFirma = new PdfPTable(10);
        PdfPTable TableVendedor = new PdfPTable(10);
        PdfPTable TableClienteCab = new PdfPTable(20);
        #endregion

        public RPedido(IWebHostEnvironment oHostEnvironment)
        {
            _oHostEnvironment = oHostEnvironment;
        }


        //class HeaderFooter : PdfPageEventHelper
        //{
        //    public override void OnEndPage(PdfWriter writer, Document document)
        //    {
        //        //base.OnEndPage(writer, document);
        //        PdfPTable tbHeader = new PdfPTable(3);
        //        tbHeader.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
        //        tbHeader.DefaultCell.Border = 0;



        //        PdfPTable tbFooter = new PdfPTable(3);
        //        tbFooter.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
        //        tbFooter.DefaultCell.Border = 0;

        //    }

        //}

        public byte[] Report(List<Pedido> pedido, List<DPedidoV> Detpedido)
        {

            _document = new Document(PageSize.A4, 10f, 10f, 20f, 30f);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();


            this.ReportHeader(pedido);
            this.ReporBody(Detpedido);

            _pdfPTable.HeaderRows = 2;
            _document.Add(_pdfPTable);
            _document.Close();

            return _memoryStream.ToArray();
        }

        private void ReportHeader(List<Pedido> cbpedido)
        {
            _pedidocab = cbpedido;
            #region Cabecera Pedido Fecha y Numero de Pedido
            _pdfPCell = new PdfPCell(new Phrase("", mediumfontSN));
            _pdfPCell.Border = 0;
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            TableTitulo.AddCell(_pdfPCell);

            foreach (var mped in _pedidocab)
            {

                _pdfPCell = new PdfPCell(new Phrase("    ", mediumfontSN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableTitulo.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("ORDEN DE PEDIDO: " + mped.Numero_Pedido, largefont));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                _pdfPCell.Border = 0;
                TableTitulo.AddCell(_pdfPCell);

                //_pdfPCell = new PdfPCell(new Phrase("", mediumfontSN));
                //_pdfPCell.Border = 0;
                //_pdfPCell.Colspan = 1;
                //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                //TableTitulo.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase("Fecha de Emisión: " + mped.Fecha_pedido.ToString("dd/mm/yyyy HH:MM") + " / " + "Fecha de Creación: " + DateTime.Now.ToString("dd/mm/yyyy"), mediumfontSN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableTitulo.AddCell(_pdfPCell);


                _document.Add(TableTitulo);

                #endregion


                #region Cabecera Datos Cliente

                #region Nombre Cliente
                _pdfPCell = new PdfPCell(new Phrase("Cliente:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableClienteCab.AddCell(_pdfPCell);



                _pdfPCell = new PdfPCell(new Phrase(mped.Persona, letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 18;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableClienteCab.AddCell(_pdfPCell);

                #endregion

                #region Direccion Cliente
                _pdfPCell = new PdfPCell(new Phrase("Dirección:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 2;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableClienteCab.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(mped.Direccion, letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 18;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableClienteCab.AddCell(_pdfPCell);

                _document.Add(TableClienteCab);

                #endregion

                #region Ruc Cliente
                _pdfPCell = new PdfPCell(new Phrase("RUC: ", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(mped.Ruc, letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                #endregion

                #region Teléfono
                _pdfPCell = new PdfPCell(new Phrase("Teléfono(s): ", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(mped.Telefono, letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);

                #endregion

                #region Datos Complementarios
                _pdfPCell = new PdfPCell(new Phrase("Motivo: ", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("VENTA", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("Lugar entrega: ", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(mped.Lugar_entrega, letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("O/C", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(" ", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("Sucursal: ", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("ALMACEN LIMA", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(" ", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                string stProy = "Leonardo Venddor";

                _pdfPCell = new PdfPCell(new Phrase(" ", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);

                //cell = New PdfPCell(New Phrase("Estimados Señores: " & stProy, letraChicaN))
                //cell.Border = BorderStyle.None
                //cell.Colspan = 4
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                //TableCliente.AddCell(cell)

                //cell = New PdfPCell(New Phrase(Space(20), letraChica))
                //cell.Border = BorderStyle.None
                //cell.Colspan = 4
                //cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                //TableCliente.AddCell(cell)

                _pdfPCell = new PdfPCell(new Phrase("Estimados Señores: " + stProy, letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 4;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCliente.AddCell(_pdfPCell);
                _document.Add(TableCliente);






                #endregion

            }
            #endregion

        }

        //private PdfPTable AddLogo()
        //{
        //    int maxColumn = 1;
        //    PdfPTable pdfPTable = new PdfPTable(1);

        //    string path = _oHostEnvironment.WebRootPath + "/Images";
        //    string imgCombine = Path.Combine(path, "ThumbIKR_Logo.png");
        //    Image img = Image.GetInstance(imgCombine);

        //    _pdfPCell = new PdfPCell(img);
        //    _pdfPCell.Colspan = 1;
        //    _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
        //    _pdfPCell.Border = 0;
        //    _pdfPCell.ExtraParagraphSpace = 0;
        //    pdfPTable.AddCell(_pdfPCell);

        //    pdfPTable.CompleteRow();

        //    return pdfPTable;
        //}
        //private PdfPTable SetPageTitle()
        //{


        //}

        private void ReporBody(List<DPedidoV> detpedido)
        {
            #region Cabecera Grilla Pedidos
            _pdfPCell = new PdfPCell(new Phrase("ITEM", letraChicaN));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            TableItem.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("DESCRIPCION", letraChicaN));
            _pdfPCell.Colspan = 6;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            TableItem.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("CANT.", letraChicaN));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            TableItem.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("V. UNIT", letraChicaN));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            TableItem.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("V. VENTA", letraChicaN));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            TableItem.AddCell(_pdfPCell);
            _document.Add(TableItem);
            #endregion
            #region Cabecera Grilla Pedidos
            _pedidobody = detpedido;
            foreach (var detped in _pedidobody)
            {
                _pdfPCell = new PdfPCell(new Phrase(detped.SECUENCIA.ToString(), letraChicaN));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableProducto.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(detped.NOMBRE, letraChicaN));
                _pdfPCell.Colspan = 6;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableProducto.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(detped.CANTIDAD.ToString(), letraChicaN));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableProducto.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(detped.PRECIO.ToString("N2"), letraChicaN));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableProducto.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(detped.IMPORTE.ToString("N2"), letraChicaN));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableProducto.AddCell(_pdfPCell);
            }
            _document.Add(TableProducto);

            #endregion
            #region Grilla Subtotales
            foreach (var mped in _pedidocab)
            {
                var fec_entrega = mped.Fecha_pedido.AddDays(2).ToString("dd/MM/yyyy");
                _pdfPCell = new PdfPCell(new Phrase("                                          ", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 18;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableSubTotal.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableSubTotal.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("Subtotal:", letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(mped.Importe_Total.ToString("N2"), letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 8;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("Descuento:", letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(mped.Importe_descuento.ToString("N2"), letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 8;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("V.Venta:", letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(mped.Valor_venta.ToString("N2"), letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 8;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableSubTotal.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("IGV:" + "18" + " %", letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(mped.Importe_igv.ToString("N2"), letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 8;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("Total " + mped.Mon, letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase(mped.Importe_Total.ToString("N2"), letraChica));
                _pdfPCell.Colspan = 1;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                TableSubTotal.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 10;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                TableSubTotal.AddCell(_pdfPCell);
                TableSubTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                TableSubTotal.SpacingAfter = 10;
                _document.Add(TableSubTotal);

                #endregion
            #region Condiciones Comerciales

                var Nominal = "SON: " + "DOS MIL SOLES CON 00 EXACTOS";
                _pdfPCell = new PdfPCell(new Phrase(Nominal, letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 10;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);
                _pdfPCell = new PdfPCell(new Phrase("CONDICIONES COMERCIALES:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 10;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("MONEDA:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 3;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(mped.Nom_moneda, letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase("LUGAR DE ENTREGA:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 3;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase(mped.Lugar_entrega, letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase("PLAZO DE ENTREGA:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 3;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase(fec_entrega, letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("FORMA DE PAGO:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 3;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("CONTADO DEPOSITO", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);



                _pdfPCell = new PdfPCell(new Phrase("VALIDEZ DE LA OFERTA:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 3;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("2" + " " + " DIAS", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 3;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

                _pdfPCell = new PdfPCell(new Phrase("OBSERVACIONES:", letraChicaN));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 3;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);


                _pdfPCell = new PdfPCell(new Phrase("", letraChica));
                _pdfPCell.Border = 0;
                _pdfPCell.Colspan = 7;
                _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
                TableCondicion.AddCell(_pdfPCell);

            }
            _document.Add(TableCondicion);


            #endregion
            #region Datos Vendedor
            TableVendedor.SpacingBefore = 20;
            _pdfPCell.Border = 0;
            _pdfPCell.Colspan = 10;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            TableVendedor.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("Leonardo Ballestero", letraChica));
            _pdfPCell.Border = 0;
            _pdfPCell.Colspan = 10;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            TableVendedor.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("ASESOR COMERCIAL", letraChicaN));
            _pdfPCell.Border = 0;
            _pdfPCell.Colspan = 10;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            TableVendedor.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("TELEFONO :" + "924935440", letraChica));
            _pdfPCell.Border = 0;
            _pdfPCell.Colspan = 10;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            TableVendedor.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("CELULAR :" + "935440871", letraChica));
            _pdfPCell.Border = 0;
            _pdfPCell.Colspan = 10;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            TableVendedor.AddCell(_pdfPCell);
            _pdfPCell = new PdfPCell(new Phrase("EMAIL :" + "ballesteroleonardojsoe@gmail.com", letraChica));
            _pdfPCell.Border = 0;
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            TableVendedor.AddCell(_pdfPCell);
            _document.Add(TableVendedor);
            #endregion

           
        } 
    }
}
