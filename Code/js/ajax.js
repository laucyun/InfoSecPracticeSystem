/*AJAX*/
var xmlhttp;
function createxmlhttp() {
    if (typeof (XMLHttpRequest) != "undefined") {
        xmlhttp = new XMLHttpRequest();
    }
    else {
        try {
            xmlhttp = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e) {
            try {
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            } catch (e) { }
        }
    }
}

function startrequest(url, arg, syn, cation) {
    if (syn == 1)
        syn = false;
    else
        syn = true;

    createxmlhttp();
    xmlhttp.open("POST", url + arg, syn);
    xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;");
    xmlhttp.onreadystatechange = function () {
        if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
            cation(xmlhttp.responseText);
        }
    };
    xmlhttp.send();
}