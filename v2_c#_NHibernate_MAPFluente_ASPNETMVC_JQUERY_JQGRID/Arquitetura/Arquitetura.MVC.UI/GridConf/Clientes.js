$().ready(function () {

    /////Grid///////

    $.ajaxSetup({
        dataFilter: function (Data, type) {
            if (type == "json" || type == undefined) {
                var msg = eval('(' + Data + ')');
                if (msg.hasOwnProperty('d'))
                    return JSON.stringify(msg.d);
                else
                    return Data;
            }
            else return Data;
        }
    });

    $("#tbGrid").jqGrid({
        url: '/Home/Listar/',
        datatype: 'json',
        contentType: "application/json; charset-utf-8",
        mtype: 'POST',
        colNames: ['ID', 'Nome', 'Cep', 'Cidade'],
        colModel: [
                   { name: 'Id', index: 'Id', width: 75, hidden: true, search: false, searchoptions: { searchhidden: true} },
                   { name: 'Nome', index: 'Nome', searchoptions: { sopt: ['eq', 'cn'] }, width: 150, editable: true, editoptions: { size: 30} },
                   { name: 'Cep', index: 'Cep', searchoptions: { sopt: ['eq', 'cn'] }, width: 150, editable: true, editoptions: { size: 20} },
                   { name: 'Cidade', index: 'Cidade', searchoptions: { sopt: ['eq', 'cn'] }, width: 80, editable: true, editoptions: { size: 20} }
                ],
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50, 60, 70, 80, 90, 100],
        pager: '#pager',
        width: 800,
        height: 260,
        sortname: 'Id',
        sopt: ['bw', 'cn'],
        viewrecords: true,
        sortorder: "desc",
        caption: "Clientes",
        jsonReader: { repeatitems: false, id: "Id" }

    });
    $("#tbGrid").jqGrid('navGrid', '#pager', { edit: true, add: true, del: true },
            { url: '/Home/Inserir/' },
            { url: '/Home/Inserir/' },
            { url: '/Home/deletar/' },
            { multipleSearch: true });
    $("#tbGrid").jqGrid('setGridParam', { usuario: data });
    $.extend($.jgrid.edit,
                    {
                        ajaxEditOptions: { contentType: "application/json;charset=utf-8" },
                        serializeEditData: function (data) {

                            alert(data.nome);

                            if (data.id == "_empty") {
                                data.id = 0;
                            }

                            return JSON.stringify({ usuario: data });
                        }
                    });
    $("#tbGrid").jqGrid('setGridParam', { usuario: data });
    $.extend($.jgrid.del,
                    {
                        ajaxDelOptions: { contentType: "application/json;charset=utf-8" },
                        serializeDelData: function (data) {
                            return JSON.stringify({ usuario: data });
                        }
                    });


    /////Fim grid/////

});