Ext.define('EthioSpark.view.UserMessageBox', {
    extend: 'Ext.MessageBox',
    xtype: 'usermessagebox',
    singleton: true,
    config: {
        title: StrRes.CompanyName[locale],
        buttons: Ext.MessageBox.OK,
        multiLine: true
    },
    showPrompt: function (message) {
        this.show({
            message: message
        });
    }
});