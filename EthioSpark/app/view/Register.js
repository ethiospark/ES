Ext.define('EthioSpark.view.Register', {
    extend: 'Ext.Container',
    xtype: 'register',
    requires: [
         'EthioSpark.view.CustomFieldSet',
         'Ext.field.Password',
         'Ext.field.Text',
         'Ext.field.Select',
         'Ext.field.Email',
         'Ext.field.DatePicker',
         'Ext.Button'
     ],
    config:
    {
        scrollable: true,
        dobYearFrom: 1900,
        dobYearTo: (new Date()).getFullYear(),
        dobDefault: (new Date())
    },
    initialize: function () {
        this.add({
            xtype: 'customfieldset',
            itemId: 'fsRegistration',
            cls: 'esFieldSet',
            defaults: {
                labelCls: 'esSmallText'
            },
            items: [
                {
                    xtype: 'selectfield',
                    itemId: 'cboNewUserGenderMode',
                    label: StrRes.GenderMode[locale],
                    options: [
                        { text: StrRes.ManSeekingWomen[locale], value: 0 },
                        { text: StrRes.WomanSeekingMen[locale], value: 1 },
                        { text: StrRes.WomanSeekingWomen[locale], value: 2 },
                        { text: StrRes.ManSeekingMen[locale], value: 3 }
                    ]
                },
                {
                    xtype: 'datepickerfield',
                    itemId: 'dpfNewUserBday',
                    label: StrRes.BirthDate[locale],
                    value: this.getDobDefault(),
                    picker: {
                        yearFrom: this.getDobYearFrom(),
                        yearTo: this.getDobYearTo()
                    }
                },
                {
                    xtype: 'textfield',
                    itemId: 'txtNewUsername',
                    required: true,
                    label: StrRes.Username[locale],
                    placeHolder: StrRes.UserNamePlaceHolder[locale],
                    autoCapitalize: false,
                    maxLength: 128
                },
                {
                    xtype: 'passwordfield',
                    itemId: 'txtNewUserPassword',
                    required: true,
                    label: StrRes.Password[locale],
                    placeHolder: StrRes.PasswordPlaceHolder[locale],
                    autoCapitalize: false,
                    maxLength: 128
                },
                {
                    xtype: 'passwordfield',
                    itemId: 'txtNewUserConfirmPassword',
                    required: true,
                    label: Ext.util.Format.format(StrRes.ConfirmPassword[locale], '<br/>'),
                    placeHolder: StrRes.ConfirmPasswordPlaceHolder[locale],
                    autoCapitalize: false,
                    maxLength: 128
                },
                {
                    xtype: 'emailfield',
                    itemId: 'txtNewUserEmail',
                    label: StrRes.Email[locale],
                    required: true,
                    placeHolder: StrRes.EmailPlaceHolder[locale],
                    autoCapitalize: false,
                    maxLength: 128
                },
                {
                    xtype: 'container',
                    docked: 'bottom',
                    padding: 10,
                    items: [{
                        xtype: 'button',
                        ui: 'confirm-round',
                        text: StrRes.Register[locale],
                        action: 'register'
                    }]
                }
            ]
        });
    }
});
