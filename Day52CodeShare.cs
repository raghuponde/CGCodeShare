
Partial view :
-----------------
it is a view which acts as part of main view and in layout or in the design where u feel that this desing 
i will be using it again in another controller action method views then make that desing into partial view and
use it everywhere becasue same design putting everywhere will be probem and any modification is there then also u 
have to modify every where that desing so if dynamic desing if u keep it in partial view then one chnage
in partial view code will effect the whole desing so one place change it every where it will effected that is partial view.
here first we will see static partial view which will not take any paramters
inside it and later on partial view which will take some model object than 

@html.partial("name of partial view ",parmaette)

@html.renderpartial("name of partial name)


and always create this partial view in shared folder because some other controller class can also use it as per its requiremnt 

