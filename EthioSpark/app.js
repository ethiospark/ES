/*
    This file is generated and updated by Sencha Cmd. You can edit this file as
    needed for your application, but these edits will have to be merged by
    Sencha Cmd when it performs code generation tasks such as generating new
    models, controllers or views and when running "sencha app upgrade".

    Ideally changes to this file would be limited and most work would be done
    in other places (such as Controllers). If Sencha Cmd cannot merge your
    changes and its generated code, it will produce a "merge conflict" that you
    will need to resolve manually.
*/

// DO NOT DELETE - this directive is required for Sencha Cmd packages to work.
//@require @packageOverrides

//<debug>
Ext.Loader.setPath({
    'Ext': 'touch/src'
});
//</debug>

//global variables
var NvgView;
var UserMessageBox;

Ext.application({
    name: 'EthioSpark',

    requires: [
        'Ext.MessageBox',
        'Ext.Ajax'
    ],
    views: [
        'NavigationView',
        'UserMessageBox',
        'Main',
        'Login',
        'Home',
        'Register'
    ],
    controllers: [
        'Main',
        'Login',
        'Home',
        'Register'
    ],
    models: ['RegistrationInfo'],
    icon: {
        '57': 'resources/icons/Icon.png',
        '72': 'resources/icons/Icon~ipad.png',
        '114': 'resources/icons/Icon@2x.png',
        '144': 'resources/icons/Icon~ipad@2x.png'
    },
    viewport: {
        autoMaximize: true
    },
    isIconPrecomposed: true,

    startupImage: {
        '320x460': 'resources/startup/320x460.jpg',
        '640x920': 'resources/startup/640x920.png',
        '768x1004': 'resources/startup/768x1004.png',
        '748x1024': 'resources/startup/748x1024.png',
        '1536x2008': 'resources/startup/1536x2008.png',
        '1496x2048': 'resources/startup/1496x2048.png'
    },

    launch: function ()
    {
        // Destroy the #appLoadingIndicator element
        Ext.fly('appLoadingIndicator').destroy();

        this.initGlobals();
        this.initAjaxSetup();

        Ext.Viewport.add(NvgView);

        var hfInitRedirect = Ext.DomQuery.selectNode("input[type=hidden][name=InitialRedirect]");
        if (hfInitRedirect != null && hfInitRedirect.value == "UserHome")
        {
            // Initialize the user home view
            NvgView.push(Ext.create('EthioSpark.view.Home'));
        }
        else
        {
            // Initialize the main view
            NvgView.push(Ext.create('EthioSpark.view.Main'));
        }

    },

    onUpdated: function ()
    {
        Ext.Msg.confirm(
            "Application Update",
            "This application has just successfully been updated to the latest version. Reload now?",
            function (buttonId)
            {
                if (buttonId === 'yes')
                {
                    window.location.reload();
                }
            }
        );
    },
    initAjaxSetup: function ()
    {
        Ext.Ajax.setMethod('POST');
        Ext.Ajax.on('beforerequest', function (conn, options, eOpts)
        {
            Ext.Viewport.setMasked({
                xtype: 'loadmask',
                message: StrRes.LoadingMessage[locale]
            });
        });

        Ext.Ajax.on('requestcomplete', function (conn, response, options, eOpts)
        {
            try
            {

                if (options != null && options.successJson && typeof (options.successJson) === 'function')
                {
                    if (response && response.responseText)
                    {
                        var jsonObj = Ext.decode(response.responseText, true);
                        if (jsonObj)
                        {
                            if (jsonObj.success == true)
                            {
                                Ext.callback(options.successJson, options.scope, [jsonObj]);
                                return;
                            } else if (jsonObj.userErrorMessage == true && jsonObj.errors != null)
                            {
                                var errorMessages = '';
                                var i;
                                if (options.errorJson && typeof (options.errorJson) === 'function')
                                {
                                    var errors = Ext.create('Ext.data.Errors');
                                    for (i = 0; i < jsonObj.errors.length; i++) {
                                        errors.add(Ext.create('Ext.data.Error', {
                                            message: jsonObj.errors[i].ErrorMessage
                                        }));
                                    }
                                    //if an error callback function is provided, invoke the method.
                                    Ext.callback(options.errorJson, options.scope, [errors]);
                                    return;
                                }
                                else
                                {
                                    //if no error callback function is provided, show the error in a message box.
                                    if (jsonObj.errors.length == 1)
                                    {
                                        errorMessages = jsonObj.errors[0].ErrorMessage;
                                    }
                                    else if (jsonObj.errors.length > 1)
                                    {
                                        for (i = 0; i < jsonObj.errors.length; i++)
                                        {
                                            if (Ext.util.Format.trim(jsonObj.errors[i].ErrorMessage))
                                            {
                                                errorMessages += Ext.util.Format.format("<li>{0}</li>", jsonObj.errors[i].ErrorMessage);
                                            }
                                        }
                                        if (errorMessages)
                                        {
                                            errorMessages = Ext.util.Format.format("<ul>{0}</ul>", errorMessages);
                                        }
                                    }

                                    if (Ext.util.Format.trim(errorMessages))
                                    {
                                        //show error message to the user.
                                        UserMessageBox.showPrompt(errorMessages);
                                        return;
                                    }
                                }
                            }

                        }
                    }

                    //unknown error message.
                    UserMessageBox.showPrompt(StrRes.GenericErrorMessage[locale]);
                }
            }
            finally
            {
                Ext.Viewport.unmask();
            }
        });

        //handle the ajax request exception event handler to switch to the login page for un-authenticated users.
        Ext.Ajax.on('requestexception', function (conn, response, options, eOpts)
        {
            try
            {
                if (response && response.status == 401)
                {
                    //show the login page.
                    NvgView.push(Ext.create('EthioSpark.view.Login'));
                } else
                {
                    //unknown error message.
                    UserMessageBox.showPrompt(StrRes.GenericErrorMessage[locale]);
                }
            }
            finally
            {
                Ext.Viewport.unmask();
            }
        });
    },

    initGlobals: function ()
    {
        NvgView = EthioSpark.view.NavigationView;
        UserMessageBox = EthioSpark.view.UserMessageBox;
    }

});

