Ext.define('EthioSpark.view.Home', {
    extend: 'Ext.Container', 
    xtype: 'home',
    config: {
        layout: {
            type: 'vbox',
            pack: 'center',
            align:'center'
        },
        items: [
                    {
                        xtype: 'panel',
                        pack:'center',
                        html: 'Well come.'
                    },
                    {
                        xtype: 'button',
                        action: 'logOut',
                        text: 'LogOut'
                    }   
              ]
        }
});
