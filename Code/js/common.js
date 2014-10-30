function $(id) { return document.getElementById(id) }
function _c(_lab) {
    return document.createElement(_lab);
}
function loadJs(_url) {
    var callback = arguments[1] || function () {
    };
    // load_js_url = _url;
    var _script = _c("SCRIPT");
    _script.setAttribute("type", "text/javascript");
    _script.setAttribute("src", _url);
    document.getElementsByTagName("head")[0].appendChild(_script);
    if (document.all) {
        _script.onreadystatechange = function () {
            if (/onload|loaded|complete/.test(_script.readyState)) {
                callback && callback();
            }
        };
    } else {
        _script.onload = function () {
            callback();
        };
    }
}
String.prototype.trim = function () {
    return this.replace(/(^\s*)|(\s*$)/g, "");
};
//换算中文字长
String.prototype.cnSize = function () {
    var arr = this.match(/[^\x00-\xff]/ig);
    return this.length + (arr == null ? 0 : arr.length);
};