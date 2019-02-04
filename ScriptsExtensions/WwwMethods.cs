public void Call<T>(string call, Func<string, T> parser, Action<T> onSuccess, Action<string> onFailure)
{
    var handler = MakeHandler(parser, onSuccess, onFailure);
    StartCoroutine(CallImpl(call, handler));
} 

public IEnumerator CallImpl<T>(string call, Action<T> handler)
{
    var www = new WWW(call);
    yield return www;
    handler(www);
}

public Action<WWW> MakeHandler<T>(Func<string, T> parser, Action<T> onSuccess, Action<string> onFailure)
{
    return (WWW www) =>
    {
        if(NoError(www)) 
        {
           var parsedResult = parser(www.text);
           onSuccess(parsedResult);
        }
        else
        {
           onFailure("error text");
        }
    }
}