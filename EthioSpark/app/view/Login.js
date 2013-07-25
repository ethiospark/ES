Ext.define('EthioSpark.view.Login', {
    extend: 'Ext.Container',
    xtype: 'login',
    requires: [
         'Ext.form.FieldSet',
         'Ext.field.Text',
         'Ext.field.Password'
     ],
    config: {
        layout: {
            type: 'vbox',
            align: 'stretch',
            pack: 'center'
        },
        items: [
            {
                xtype: 'customfieldset',
                itemId: 'fsLogin',
                items: [
                            {
                                xtype: 'textfield',
                                itemId: 'txtUsername',
                                placeHolder: StrRes.Username[locale],
                                autoCapitalize:false
                            },
                            {
                                xtype: 'passwordfield',
                                itemId: 'txtPassword',
                                placeHolder: StrRes.Password[locale],
                                autoCapitalize: false
                            },
                            {
                                 xtype: 'container',
                                 docked: 'bottom',
                                 padding: 10,
                                 items: [{
                                            xtype: 'button',
                                            ui: 'action',
                                            text: StrRes.Login[locale],
                                            action: 'login'
                                        }]
                            }
                      ]
              },
              {
                     xtype: 'container',
                     docked: 'bottom',
                     layout: {
                         type: 'vbox',
                         align: 'center',
                         pack: 'center'
                     },
                     padding: '0 0 20 0',
                     items: [
                                {
                                    xtype: 'button',
                                    ui: 'small',
                                    text: Ext.String.format(StrRes.SignUp[locale], StrRes.CompanyName[locale]),
                                    action: 'signup'
                                },
                                {
                                    xtype:'panel',
                                    cls: 'esSmallText', 
                                    padding: '10 0 0 0',
                                    html: '&copy; '+ Ext.String.format(StrRes.CopyRight[locale], StrRes.CompanySite[locale])
                                }
                           ]
              }
        ]
    }
});
