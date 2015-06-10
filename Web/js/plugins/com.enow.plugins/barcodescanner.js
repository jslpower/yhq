/**
* 二维码扫描插件 汪奇志 2013-12-19
*/

cordova.define("com.enow.plugins.barcodescanner", function(require, exports, module) {
    var exec = require('cordova/exec');

    module.exports = {
        /**
        * 二维码扫描
        * @str:""
        * @callback:A success callback function. Assuming your exec call completes successfully, this function executes along with any parameters you pass to it.
        * @error: An error callback function. If the operation does not complete successfully, this function executes with an optional error parameter.
        */
        scan: function(str, callback, error) {
            exec(callback, error, "BarcodeScanner", "scan", [str]);
        }
    };
});
