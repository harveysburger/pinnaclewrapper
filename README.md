# C# Wrapper for the PinnacleSports API

A complete API client that builds on the <a href="https://www.pinnacle.com/en/api/manual">PinnacleSports API Documentation</a>

<strong>Update:</strong>

Library now targeting .netstandard 2.0 so should work from both .Net Framework 4.7.2 and .Net Core 2.2
You can override the default api version, v1, for the Fixtures and Odds API
PinnacleClient constructor now has an optional baseUrl parameter, defaulted to the value that was previously hardcoded in the class.
GetFeed functionalities were removed as they are deprecated by Pinnacle, use GetFixtures and GetOdds instead. If you need GetFeed revert to v1.0 of this library.

<strong>References:</strong>

These references are available via NuGet.

    Newtonsoft.Json 
	Microsoft.AspNet.WebApi.Client package

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

This library started off as a cleaned up version of the Pinnacle API wrapper created by <a href="http://www.broculos.net/2014/04/pinnacle-sports-how-to-implement-rest.html">Nuno Freitas</a> and has been extended and tweaked along the way since.

The initial location of this wrapper was https://github.com/anderj017/pinnaclewrapper, on May 23rd 2019 the project was transferred to https://github.com/harveysburger/pinnaclewrapper. Thanks @anderj017

	
Enjoy!
