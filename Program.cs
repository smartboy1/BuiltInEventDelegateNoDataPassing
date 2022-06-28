//.NET  Framework beinhaltet build in Delegaten Typen EventHandler und EventHandler<TEventArgs> für den meisten gägigen Events
//das EventHandler Delegate wird für alle Events, die keine Event Ereignisse Daten haben.
//das EventHandle<TEventArgs> für alle Events, die Event Daten beinhalten.


//Beispiel für keine Event Daten 

class Program // subscriber klasse 
{


    //Objects
    public static void Main()
    {
        ProcessBusinessLogic bl = new ProcessBusinessLogic();
        //fügt den eventHandler zum Event aus der publisher klasse  hinzu-> eventListe aller  eventHandler

        bl.ProcessCompleted += EventHandlerMeth;

        //start the Process
        bl.StartProcess();

    }



    //eventHandler 
    public static void EventHandlerMeth(object sender,EventArgs e)
    {

        Console.WriteLine("Event Process completed by event handler ");

    }

}










public class ProcessBusinessLogic  // publisher class
{

    //Deklartion eines Event ,das den built-in EventHandler von.NET Framework benutzt
    public event EventHandler ProcessCompleted;


    //define methode to start the Process in the subscriber class 
    public void StartProcess()
    {
        Console.WriteLine("Process Started!");

        // some code here..


        //call the OnEventName method 
        OnProcessCompleted(EventArgs.Empty); // no event data passing

    }

    //methode  mit  OnEventName hier OnProcessCompleted
    //protected wegen Kapselung d.h nur abgelietete Klassen
    //virtual wegen abgeleitet Klassen können dann die Methode OnProcessCompleted überschreiben

    protected virtual void OnProcessCompleted(EventArgs e)
  
    {
        //überprüfen ob event ProcessCompleted nicht NULL ist mit ?
        ProcessCompleted?.Invoke(this,e);


    }


}  // end of publisher




