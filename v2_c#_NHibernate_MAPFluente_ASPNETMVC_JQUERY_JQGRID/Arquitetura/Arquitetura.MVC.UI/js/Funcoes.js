//Função que dispara o erro do jqGrid
function disparaMensagemErro(erroJqGrid) {

    jQuery.jgrid.info_dialog(jQuery.jgrid.errors.errcap, '<div class="teste">Ticket de erro:</br></br></div><div>' + erroJqGrid.responseText + '</div>', '', { width: 750 });
    var name_element = document.getElementById("info_head");
    name_element.style.background = "#EE0000";
    name_element.style.borderColor = "#EE0000";

    name_element = document.getElementById("info_dialog");
    name_element.style.borderColor = "#EE0000";
    name_element.style.borderWidth = "1px";
    name_element.style.boxShadow = "0px 0px 0px #888888"
}

//Função que pega o gráfico, converte para SVG e depois converte para PNG
function getImgData(chartContainer) {
    var chartArea = chartContainer.children[0];
    var svg = chartArea.innerHTML.substring(chartArea.innerHTML.indexOf("<svg"), chartArea.innerHTML.indexOf("</svg>") + 6);

    var doc = chartContainer.ownerDocument;
    var canvas = doc.createElement('canvas');
    canvas.setAttribute('width', chartArea.offsetWidth);
    canvas.setAttribute('height', chartArea.offsetHeight);


    canvas.setAttribute(
            'style',
            'position: absolute; ' +
            'top: ' + (-chartArea.offsetHeight * 2) + 'px;' +
            'left: ' + (-chartArea.offsetWidth * 2) + 'px;');
    doc.body.appendChild(canvas);
    canvg(canvas, svg);
    //var imgData = canvas.toDataURL("image/png").replace("image/png", "image/octet-stream");
    //var imgData = canvas.toDataURL();
    window.open(canvas.toDataURL(), "toDataURL() image", "width=900px, height=500px");
    canvas.parentNode.removeChild(canvas);
    return imgData;
}

//Função para salvar como imagem
function saveAsImg(chartContainer) {
    var imgData = getImgData(chartContainer);
    //window.location = imgData;
}

//Função para imprimir gráfico
function PrintDiv(div, tituloRelatorio, fase) {
    var tituloDoRelatorio = "";
    switch (fase) {
        case "1":
            tituloDoRelatorio = tituloRelatorio + " - 1ª Fase"
            break;
        case "2":
            tituloDoRelatorio = tituloRelatorio + " - 2ª Fase"
            break;
        default:
            tituloDoRelatorio = tituloRelatorio;
    }
    
    $('#' + div).printElement({ pageTitle: tituloDoRelatorio, printMode: 'popup'
         , printBodyOptions:
            {
                styleToAdd: '-webkit-transform:rotate(270deg);-moz-transform:rotate(270deg);-o-transform:rotate(270deg);width:1100px!important;height:300px!important;margin-left:-200px;margin-top:280px;'
            }
    });
}