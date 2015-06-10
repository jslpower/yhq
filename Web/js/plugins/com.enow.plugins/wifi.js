/**
* wifi管理插件 汪奇志 2013-12-20
*/

cordova.define("com.enow.plugins.wifi", function(require, exports, module) {
    var exec = require('cordova/exec');

    module.exports = {
        /**
        * 开启wifi
        * @str:""
        * @callback:A success callback function. Assuming your exec call completes successfully, this function executes along with any parameters you pass to it.
        * @error: An error callback function. If the operation does not complete successfully, this function executes with an optional error parameter.
        */
        open: function(str, callback, error) {
            exec(callback, error, "Wifi", "open", [str]);
        },
        /**
        * 关闭wifi
        * @str:""
        * @callback:A success callback function. Assuming your exec call completes successfully, this function executes along with any parameters you pass to it.
        * @error: An error callback function. If the operation does not complete successfully, this function executes with an optional error parameter.
        */
        close: function(str, callback, error) {
            exec(callback, error, "Wifi", "close", [str]);
        }
    };
});