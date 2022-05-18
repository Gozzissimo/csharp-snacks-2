// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


//Scrivere un codice csharp che crea un accumulatore e poi lo utilizza
//Esempio: var accumulatore1 = CreaAccumulatore();
//accumulatore(10) => 10
//accumulatore(40) => 50
//accumulatore(90) => 140

/*
 * in javascript sarebbe così (una CLOSURE):
 * 
 * function() {
 *      let tot = 0;
 *      return (n) => {
 *          tot += n;
 *          return tot;
 *      }
 *  }
 *  
 */

//1. Per evitare di dichiarare un tipo uso VAR
var Maker = () =>
{
    long totale = 0;
    return (int n) =>
    {
        totale += n;
        return totale;
    };
};

var acc1 = Maker();
var acc2 = Maker();

//Console.WriteLine(acc1(10));
//Console.WriteLine(acc1(10));
//Console.WriteLine(acc1(10));
//Console.WriteLine(acc2(10));
//Console.WriteLine(acc2(10));
//Console.WriteLine(acc2(10));

//var somma = (int n) => { n++; Console.WriteLine(n); };
//somma(9);

//Data una lista di interi, metterli tutti al quadrato

List<int> listnormal = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8}; // lista di partenza
List<int> lsquare = ElevaAlQuadrato(listnormal); //lista nuova che sarà uguale a result dopo il foreach

foreach (int n in lsquare)
{
    Console.WriteLine(n);
}

List<int> ElevaAlQuadrato(List<int> list)
{
    List<int> result = new List<int>();
    foreach (int i in list)
    {
        int ialqudrato = i * i;
        result.Add(ialqudrato);
    }
    return result;
}

//Data una lista di interi, metterli tutti al cubo

List<int> lcubo = ElevaAlCubo(listnormal); //lista nuova che sarà uguale a result dopo il foreach

foreach (int n in lcubo)
{
    Console.WriteLine(n);
}

List<int> ElevaAlCubo(List<int> list)
{
    List<int> result = new List<int>();
    foreach (int i in list)
    {
        int ialcubo = i * i * i;
        result.Add(ialcubo);
    }
    return result;
}


//--------------------------
//VERY IMPORTANT, questa è una funzione che data una lista di interi e una funzione qualsiasi da come ristultato una lista di interi

List<int> EseguiIlCalcolo(List<int> li, Func<int, int> fun)
{
    List<int> lout = new List<int>();
    foreach (int n in li)
        lout.Add(fun(n));
    return lout;
}

//--------------------------


List<int> lcalcolo = EseguiIlCalcolo(listnormal, (n) => n * (n + 1) / 2);
foreach (int n in lcalcolo)
    Console.WriteLine(n);
//Abbiamo in questo modo costruito una funzione "generale" per trasformare
//tutti gli elementi di una stringa da numero intero a numero intero => nuovo = f(vecchio);
//Purtroppo per come è stata costruita, questa funzione si applica esclusivamente alle lista di numeri interi 
//e torna una lista di numeri interi

//--------------------

//Funzione SELECT (è LA MAP DI CSHARP) che semplifica tantissimo TUTTI i lavori su liste, dizionari, vettori ecc.
//Il metodo select ti permette di iterare su una lista e modificare gli elementi usando una funzione di callback, che verrà eseguita su ognungo degli elementi della lista.

var listaDeiQuadrati = listnormal.Select(n => n * n);

foreach (int n in listaDeiQuadrati)
{
    Console.WriteLine(n);
}

//--------------------

//VERY IMPORTANT

//FUNZIONE WHERE è LA FILTER DI CSHARP
//Data una lista di interi estrarre la lista che contiene tutti i numeri pari
var lpari = listnormal.Where(n => (n % 2) == 0);

//-----------------------

//ORDINARE UNA LISTA DI INTERI

listnormal = new List<int>() {4, 7, 8, 10, 2, 6, 2};
listnormal.Sort();//Dal più piccolo al più grande, oppure secondo dei paramtri
listnormal.Reverse();//Nel caso la volessi al contrario
foreach (int n in listnormal)
{
    Console.WriteLine(n);
}

//Data la lista di stringhe {"uno", "due", "tre", "quattro", "cinque", "Sei"}
//ordinarla e stamparla in verso decrescente
//!!ordinamento lessicografico
//numeri davanti a tutto, maiuscole prima delle minuscole

//Formulazione 1
List<string> lstr = new List<string>() { "uno", "due", "tre", "quattro", "cinque", "Sei" };
//Con gli insiemi ordinati
SortedSet<string> ords = new SortedSet<string>();
foreach (String s in lstr)
    ords.Add(s);
foreach (String s in ords)
    Console.WriteLine(s);

//Formulazione 2
Console.WriteLine("\n\n\n\n");
lstr = new List<string>() { "uno", "due", "tre", "quattro", "cinque", "Sei" };
lstr.Sort();
lstr.Reverse();
foreach (String s in lstr)
    Console.WriteLine(s);

//Formulazione 3
Console.WriteLine("\n\n\n\n");
lstr = new List<string>() { "uno", "due", "tre", "quattro", "cinque", "Sei" };
lstr.Sort((string s1, string s2) => -s1.CompareTo(s2));
foreach (string s in lstr)
    Console.WriteLine(s);


//ESERCIZIO FINALE
//DATA UNA LISTA DI COPPIE <string, int> stamparle ordinate rispetto alla stringa
List<Tuple<string, int>> lcoppie = new List<Tuple<string, int>>()
{
    new Tuple<string, int>("uno", 1),
    new Tuple<string, int>("due", 21),
    new Tuple<string, int>("quattro", 41),
    new Tuple<string, int>("sette", 71),
    new Tuple<string, int>("diciannove", 191),
};

Console.WriteLine();
lcoppie.Sort();
lcoppie.ForEach(x => Console.WriteLine(x));

//foreach (var s in lcoppie)
//    Console.WriteLine(s);

//Ordinare per il secondo campo della tupla
lcoppie.Sort((t1, t2) => t1.Item2.CompareTo(t2.Item2));
foreach (var s in lcoppie)
    Console.WriteLine(s);

List<Tuple<int, int, int>> lterne = new List<Tuple<int, int, int>>()
{
    new Tuple<int, int, int>(1, 2, 3),
    new Tuple<int, int, int>(5, 5, 2),
    new Tuple<int, int, int>(2, 4, 11),
    new Tuple<int, int, int>(12, 15, 21),
    new Tuple<int, int, int>(55, 45, 32),
    new Tuple<int, int, int>(1, 2, 4),
    new Tuple<int, int, int>(1, 3, 0),
    new Tuple<int, int, int>(5, 5, 1)
};
lterne.Sort();
Console.WriteLine(String.Join("\t", lterne));

//Se vogliamo vedere la velocità di una parte del codice 
double microseconds = DateTime.Now.Ticks / (TimeSpan.TicksPerMillisecond / 1000.0);
Console.WriteLine("microseconds: {0}", microseconds);
