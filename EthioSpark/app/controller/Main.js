Ext.define('EthioSpark.controller.Main', {
    extend: 'Ext.app.Controller',
    
    config: {
        control: {
            goToLoginViewButton: {
                tap: 'goToLogin'
            }
        },

        refs: {
            goToLoginViewButton: 'button[action=goToLoginView]'
        }
    },

    goToLogin: function () {
        NvgView.push(Ext.create('EthioSpark.view.Login'));
    }
});