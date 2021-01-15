﻿# Extensions.dll contains extension methods that enhance existing C# classes thus making life easier for developers.
[![icon](https://github.com/cjvandyk/Quix/blob/master/Extensions/Images/Extensions-64x64.png?raw=true)](https://github.com/cjvandyk/quix/Extensions)<br>
![GIF](https://github.com/cjvandyk/Quix/blob/master/Extensions/Images/Extensions.gif)<br>
![License](https://img.shields.io/github/license/cjvandyk/quix) ![Maintained](https://img.shields.io/maintenance/yes/2021) [![GitHub Release](https://img.shields.io/github/release/cjvandyk/quix.svg)](https://GitHub.com/cjvandyk/quix/releases/) ![NuGet Badge](https://buildstats.info/nuget/Extensions.CS) [![Repo Size](https://img.shields.io/github/repo-size/cjvandyk/quix)](https://github.com/cjvandyk/quix/Extensions) [![Closed Issues](https://img.shields.io/github/issues-closed/cjvandyk/quix.svg)](https://GitHub.com/cjvandyk/quix/issues?q=is%3Aissue+is%3Aclosed) [![Open Issues](https://img.shields.io/github/issues/cjvandyk/quix.svg)](https://github.com/cjvandyk/quix/issues) [![Contributors](https://img.shields.io/github/contributors/cjvandyk/quix.svg)](https://GitHub.com/cjvandyk/quix/graphs/contributors/) ![Languages](https://img.shields.io/github/languages/count/cjvandyk/quix.svg) [![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/ExtensionsCS/Extensions?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) [![Discord](https://github.com/cjvandyk/Quix/blob/master/Extensions/Images/Discord.png?raw=true)](https://discord.com/channels/799027565465305088/799027565993394219) [![Twitter](https://img.shields.io/twitter/follow/cjvandyk?style=social)](https://twitter.com/intent/follow?screen_name=cjvandyk)

The following classes have been extended:

    - System.Diagnostics.Process
    - System.Net.WebException
    - System.Object
    - System.String
    - System.Text.StringBuilder

with these methods:

- ### **Elevate()**
    > _Restarts the current process with elevated permissions.<br>
        For example:<br>
            `System.Diagnostics.Process.GetCurrentProcess().Elevate(args)`<br>
        will restart the current console app in admin mode._

- ### **Get()**
    > _Language extension for properties.  Use to set the value of the<br>
        extension property in question.<br>
        For example:<br>
            `Microsoft.SharePoint.Client client = new Microsoft.SharePoint.Client("https://blog.cjvandyk.com");`<br>
            `client.ExecutingWebRequest += ClientContext_ExecutingWebRequest;`<br>
            `client.Set("HeaderDecoration", "NONISV|Crayveon|MyApp/1.0");`<br>
        This allows the creation of the extension property "HeaderDecoration"<br>
        which can be changed as needed.  Later in the delegate method we<br>
        refer back to the extension property value thus:<br>
            `private void ClientContext_ExecutingWebRequest(object sender, WebRequestEventArgs e)`<br>
            `{`<br>
                `e.WebRequestExecutor.WebRequest.UserAgent = (string)e.Get("HeaderDecoration");`<br>
            `}`<br>
    NOTE: We did not have to access the ClientContext class in order to<br>
        retrieve the "HeaderDecoration" value since the extension was<br>
        done against the System.Object class.  As such, any object can<br>
        be used to retrieve the extension property value, as long as<br>
        you know the key value under which the property was stored and<br>
        you know the type to which the returned value needs to be cast.<br>
        A derived override method for Get() and Set() can be defined<br>
        using specific class objects if finer controls is needed.<br>_

- ### **GetUrlRoot()**
    > _Get the URL root for the given string object containing a URL.<br>
        For example:<br>
            `"https://blog.cjvandyk.com".GetUrlRoot()`<br>
        will return "https://blog.cjvandyk.com" whereas<br>
            `"https://blog.cjvandyk.com/sites/Approval".GetUrlRoot()`<br>
        will also return "https://blog.cjvandyk.com"._

- ### **IsAlphabetic()**
    > _Validates that the given string object contains all alphabetic<br>
        characters (a-z and A-Z) returning True if it does and False if<br>
        it doesn't.<br>
        For example:<br>
            `"abcXYZ".IsAlphabetic()`<br>
        will return True whereas<br>
            `"abc123".IsAlphabetic()`<br>
        will return False._
    
- ### **IsNumeric()**
    > _Validates that the given string object contains all numeric<br>
        characters (0-9) returning True if it does and False  if it<br>
        doesn't.<br>
        For example:<br>
            `"123456".IsNumeric()`<br>
        will return True whereas<br>
            `"abc123".IsNumeric()`<br>
        will return False._

- ### **IsAlphaNumeric()**
    > _Validates that the given string object contains all alphabetic<br>
        and/or numeric characters (a-z and A-Z and 0-9) returning True if it<br>
        does and False  if it doesn't.<br>
        For example:<br>
            `"abc123".IsAlphaNumeric()`<br>
        will return True whereas<br>
            `"abcxyz".IsAlphaNumeric()`<br>
        will also return True and<br>
            `"123456".IsAlphaNumeric()`<br>
        will also return True but<br>
            `"abc!@#".IsAlphaNumeric()`<br>
        will return False._
    
- ### **IsChar()**
    > _This method takes a char[] as one of its arguments against which the<br>
        given string object is validated.  If the given string object contains<br>
        only characters found in the char[] it will return True, otherwise it<br>
        will return False.<br>
        For example:<br>
            `"aacc".IsChar(new char[] {'a', 'c'})`<br>
        will return True whereas<br>
            `"abc123".IsChar(new char[] {'a', 'c'})`<br>
        will return False._
   
- ### **IsUrlRoot()**
    > _Check if the given string object containing a URL, is that of the<br>
        URL root only.  Returns True if so, False if not.<br>
        For example:<br>
            `"https://blog.cjvandyk.com".IsUrlRootOnly()`<br>
        will return True whereas<br>
            `"https://blog.cjvandyk.com/sites/Approval".IsUrlRootOnly()`<br>
        will return False._

- ### **Lines()**
    > _This method returns the number of lines/sentences in the given string<br>
        object._

- ### **LoremIpsum()**
    > _Poplates the given string with a given number of paragraphs of dummy<br>
        text in the lorem ipsum style.
        For example:<br>
            `"".LoremIpsum(2)`<br>
        would yield<br>
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer<br> 
            aliquam arcu rhoncus erat consectetur, quis rutrum augue tincidunt.<br> 
            Suspendisse elit ipsum, lobortis lobortis tellus eu, vulputate<br> 
            fringilla lorem. Cras molestie nibh sed turpis dapibus sollicitudin<br> 
            ut a nulla. Suspendisse blandit suscipit egestas. Nunc et ante mattis<br> 
            nulla vehicula rhoncus. Vivamus commodo nunc id ultricies accumsan.<br> 
            Mauris vitae ante ut justo venenatis tempus.<br>
            <br>
            Nunc posuere, nisi eu convallis convallis, quam urna sagittis ipsum,<br> 
            et tempor ante libero ac ex. Aenean lacus mi, blandit non eros luctus,<br> 
            ultrices consectetur nunc. Vivamus suscipit justo odio, a porta massa<br> 
            posuere ac. Aenean varius leo non ipsum porttitor eleifend. Phasellus<br> 
            accumsan ultrices massa et finibus. Nunc vestibulum augue ut bibendum<br> 
            facilisis. Donec est massa, lobortis quis molestie at, placerat a<br> 
            neque. Donec quis bibendum leo. Pellentesque ultricies ac odio id<br> 
            pharetra. Nulla enim massa, lacinia nec nunc nec, egestas pulvinar<br> 
            odio. Sed pulvinar molestie justo, eu hendrerit nunc blandit eu.<br> 
            Suspendisse et sapien quis ipsum scelerisque rutrum."<br>_

- ### **Retry()**
    > _Checks if a System.Net.WebException contains a "Retry-After" header.<br>
        If it does, it sleeps the thread for that period (+ 60 seconds)<br>
        before reattempting to HTTP call that caused the exception in the<br>
        first place.  If no "Retry-After" header exist, the exception is<br>
        simply rethrown.<br>
        For example:<br>
            `System.Net.HttpWebRequest request ...`<br>
            `Try`<br>
            `{`<br>
                `request.GetResponse();`<br>
            `}`<br>
            `Catch (System.Net.WebException ex)`<br>
            `{`<br>
                `ex.Retry(request);`<br>
            `}`<br>_

- ### **ReplaceTokens()**
    > _Takes a given string object and replaces 1 to n tokens in the string<br>
        with replacement tokens as defined in the given Dictionary of strings._

- ### **Set()**
    > _Language extension for properties.  Use to set the value of the<br>
        extension property in question.<br>
        For example:<br>
            `Microsoft.SharePoint.Client client = new Microsoft.SharePoint.Client("https://blog.cjvandyk.com");`<br>
            `client.ExecutingWebRequest += ClientContext_ExecutingWebRequest;`<br>
            `client.Set("HeaderDecoration", "NONISV|Crayveon|MyApp/1.0");`<br>
        This allows the creation of the extension property "HeaderDecoration"<br>
        which can be changed as needed.  Later in the delegate method we<br>
        refer back to the extension property value thus:<br>
            `private void ClientContext_ExecutingWebRequest(object sender, WebRequestEventArgs e)`<br>
            `{`<br>
                `e.WebRequestExecutor.WebRequest.UserAgent = (string)e.Get("HeaderDecoration");`<br>
            `}`<br>
        NOTE: We did not have to access the ClientContext class in order to<br>
        retrieve the "HeaderDecoration" value since the extension was<br>
        done against the System.Object class.  As such, any object can<br>
        be used to retrieve the extension property value, as long as<br>
        you know the key value under which the property was stored and<br>
        you know the type to which the returned value needs to be cast.<br>
        A derived override method for Get() and Set() can be defined<br>
        using specific class objects if finer controls is needed.<br>

- ### **ToBinary()**
    > _This method returns the given string represented in 1s and 0s as<br>
        a binary result.<br>
        For example:<br>
            `"This test".ToBinary()`<br>
        will return <br>
            `1010100 1101000 1101001 1110011 100000 1110100 1100101 1110011 1110100`_

- ### **ToEnum()**
    > _This method matches a given string to the given enum set and returns<br>
        the matched enum.<br>
        For example:<br>
            `enum testEnum { first, second, third };`<br>
            `var testEnumResult = "first".ToEnum<testEnum>();`<br>
            `Console.WriteLine(testEnumResult == testEnum.first);`<br>
        will return<br>
        `True`_

- ### **Words()**
    > _This method returns the number of words used in the given string<br>
        object.
        For example:<br>
            `"This is my test".Words()`<br>
        will return 4 whereas<br>
            `"ThisIsMyTest".Words()`<br>
        will return 1._
