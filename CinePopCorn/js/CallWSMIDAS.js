function callWebServiceMIDAS(CNPJ) {
    jQuery.support.cors = true;

    var url = "https://crm-api.nddigital.com.br/webapi/api/values/cnpj=" + CNPJ.replace(".", "").replace("-", "").replace("/", "").replace(".", "") + "/ReceitaFederalCNPJ";

    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            SerObject(data);
        },
        error: function (xhr, status, error) {
            //debugger;
            alert(error);
        }
    });
}


function SerObject(data) {
    var xmlDoc;
    var parser = new DOMParser();
    try {
        xmlDoc = parser.parseFromString(data, "text/xml");
    } catch (e) {
        alert("XML parsing error");
        return null;
    };
    FillTable(xmlDoc);
}


function FillTable(xmlDoc) {
    if (xmlDoc.documentElement.getElementsByTagName("Rows").length == 0) return;
    if (xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns").length == 0) return;

    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "RazaoSocial", "#idrazaosocial");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "NomeFantasia", "#idnomefantasia");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "ListaCNAE", "#idareadeatuacao");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "Bairro", "#idbairro");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "CEP", "#idcep");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "Logradouro", "#idenderecoconta");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "Numero", "#idnumeroendereco");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "Municipio", "#idmunicipio");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "UF", "#iduf");
    ProcuraeSetaCampo(xmlDoc.documentElement.getElementsByTagName("Rows")[0].getElementsByTagName("Columns")[0], "Complemento", "#idcomplemento");
}

function ProcuraeSetaCampo(xml, strXmlField, strCrmField) {
    var xmlNode;
    for (var i = 0; i < xml.childNodes.length; i++) {
        xmlNode = xml.childNodes[i].getElementsByTagName("Key");
        if (xmlNode[0].textContent == strXmlField) {
            if (strCrmField != null) {
                if (xmlNode[0].parentNode.getElementsByTagName("Value")[0].textContent.indexOf("***") == -1) {
                    $(strCrmField).val(xmlNode[0].parentNode.getElementsByTagName("Value")[0].textContent);
                    return "";
                }
            }
            else return xmlNode[0].parentNode.getElementsByTagName("Value")[0].textContent
        }
    }
}