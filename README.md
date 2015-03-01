# C# Wrapper for the PinnacleSports API

A complete API client that builds on the <a href="http://www.pinnaclesports.com/en/api/manual">PinnacleSports API Documentation</a>

I have cleaned up and extended the wrapper created by <a href="http://www.broculos.net/2014/04/pinnacle-sports-how-to-implement-rest.html">Nuno Freitas</a> to support the JSON functions (GetClientBalance, PlaceBet, GetLine, GetBets, GetInRunning).

<strong>References:</strong>

These references are available via NuGet.

    Newtonsoft.Json 
	System.Net.Http.Formatting (part of the Microsoft.AspNet.WebApi.Client package)

<strong>Usage:</strong>

Here's an example of getting all lines for upcoming E-Sports matches (across all E-Sports leagues):

    var client = new PinnacleClient("username", "password", "AUD", OddsFormat.Decimal);
    var leagues = client.GetLeagues(12);    // 12 is the E-Sports Sport Id. Use GetSports() to find others.
    var feed = client.GetFeed(12, leagues.Select(x => x.Id).ToArray());
    
Refreshing lines:

According to the Pinnacle API Fair Use Policy GetFeed can be called every 5 seconds when supplying the timestamp parameter that's returned from GetFeed or every 60 seconds otherwise.

Example (continuing from above):

    Thread.Sleep(5000);    // wait 5 seconds between calls!
    var newFeed = client.GetFeed(12, leagues.Select(x => x.Id).ToArray(), feed.Timestamp);

A future release will monitor lines for changes and fire an event when it updates.
	
Enjoy!
