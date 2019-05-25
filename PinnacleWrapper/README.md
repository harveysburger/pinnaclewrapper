# C# Wrapper for the PinnacleSports API

A complete API client that builds on the [PinnacleSports API Documentation](https://www.pinnacle.com/en/api/manual)

**Update**

- First version published on nuget.org
- Library now targeting .netstandard 2.0 so should work from both .Net Framework 4.7.2 and .Net Core 2.2
- You can override the default api version, v1, for the Fixtures and Odds API
- PinnacleClient constructor now has an optional baseUrl parameter, default value `https://api.pinnacle.com`
- GetFeed functionalities removed as they are deprecated by Pinnacle, use GetFixtures and GetOdds instead. If you need GetFeed revert to v1.0 of this library. 


**References**

These references are available via NuGet.

- Newtonsoft.Json 
- Microsoft.AspNet.WebApi.Client package

**Usage**

Here's an example of getting all lines for upcoming Tennis matches (across all leagues):

```
var client = new PinnacleClient("username", "password", "AUD", OddsFormat.Decimal);
var fixtures = client.GetFixtures(new GetFixturesRequest(33));	// 33 is the Tennis SportId. This gets all Events currently offered
var odds = client.GetOdds(new GetOddsRequest(12)); // this retrieves the odds that correspond to each fixture.
```

Refreshing lines:

Use the "since" parameter with GetFixtures (update current events) and GetOdds (get latest odds).

Example (continuing from above):

```
Thread.Sleep(5000);  // wait between calls one way or another. Calling the API too aggressively may get you blocked from using the API.
var oddsChanges = await _client.GetOdds(new GetOddsRequest(12, odds.Last));   
```

This library started off as a cleaned up version by anderj017 of the [Pinnacle API wrapper created by Nuno Freitas](http://www.broculos.net/2014/04/pinnacle-sports-how-to-implement-rest.html) and has been extended and tweaked by various people since.


The initial location of this wrapper was https://github.com/anderj017/pinnaclewrapper
	
Enjoy!
