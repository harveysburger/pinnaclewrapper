# C# Wrapper for the PinnacleSports API

A complete API client that builds on the <a href="http://www.pinnaclesports.com/en/api/manual">PinnacleSports API Documentation</a>

<strong>Update:</strong>

Updated various IDs in the models from int to long
Added Status property in PeriodType
Added ParentId property in FixturesEvent
New enum with the various period status
Added optional baseAddress to PinnacleClient constructor to hit API located somewhere other than https://api.pinnacle.com
Added optional apiVersion parameter in GetOddsRequest and GetFixturesRequests

Pinnacle has deprecated GetFeed, instead offering GetFixtures and GetOdds. The wrapper has kept GetFeed for legacy purposes but it will be removed in a future release.

<strong>References:</strong>

These references are available via NuGet.

	Newtonsoft.Json 
	Microsoft.AspNet.WebApi.Client

<strong>Usage:</strong>

Here's an example of getting all lines for upcoming E-Sports matches (across all E-Sports leagues):

	var client = new PinnacleClient("username", "password", "AUD", OddsFormat.Decimal);
	var fixtures = client.GetFixtures(new GetFixturesRequest(12));	// 12 is the E-Sports Sport Id. This gets all Esports Events currently offered
	var odds = client.GetOdds(new GetOddsRequest(12)); // this retrieves the odds that correspond to each fixture.

Refreshing lines:

Use the "since" parameter with GetFixtures (update current events) and GetOdds (get latest odds).

Example (continuing from above):

    Thread.Sleep(5000);    // wait 5 seconds between calls!
    var var odds2 = await _client.GetOdds(new GetOddsRequest(12, odds.Last));

A future release will monitor lines for changes and fire an event when it updates.

I have cleaned up and extended the wrapper created by <a href="http://www.broculos.net/2014/04/pinnacle-sports-how-to-implement-rest.html">Nuno Freitas</a> to support the JSON functions (GetClientBalance, PlaceBet, GetLine, GetBets, GetInRunning, GetFixtures and GetOdds).
	
Enjoy!
