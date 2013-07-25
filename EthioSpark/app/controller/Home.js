Ext.define('EthioSpark.controller.Home', {
    extend: 'Ext.app.Controller',

    config: {
        control: {
            cmdLogOut: {
                tap: 'logOut'
            }
        },

        refs: {
            cmdLogOut: 'button[action=logOut]'
        }
    },

    logOut: function () {
        Ext.Ajax.request({
            url: 'Account/LogOff',
            scope: this,
            successJson: function (response) {
                Ext.Msg.alert('Title', 'You are successfully logged out.', Ext.emptyFn);
            }
        });
    }
});