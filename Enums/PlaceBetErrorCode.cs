using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlaceBetErrorCode
    {
        AllBettingClosed,               //ALL_BETTING_CLOSED	Betting is not allowed at this moment
        AllLiveBettingClosed,           //ALL_LIVE_BETTING_CLOSED	Live betting is not allowed at this moment
        BlockedClient,                  //BLOCKED_CLIENT	Client is no longer active
        InvalidCountry,                 //INVALID_COUNTRY	Client country is not allowed for betting
        BlockedBetting,                 //BLOCKED_BETTING	Not allowed betting for the client
        InvalidEvent,                   //INVALID_EVENT	Invalid eventid
        AboveMaxBetAmount,              //ABOVE_MAX_BET_AMOUNT	Stake is above allowed maximum amount
        BelowMinBetAmount,              //BELOW_MIN_BET_AMOUNT	Stake is below allowed minimum amount
        OfflineEvent,                   //OFFLINE_EVENT	Bet is submitted on a event that is offline
        InsufficientFunds,              //INSUFFICIENT_FUNDS	Bet is submitted by a client with insufficient funds
        LineChanged,                    //LINE_CHANGED	Bet is submitted on a line that has changed
        RedCardsChanged,                //RED_CARDS_CHANGED	Bet is submitted on a live soccer event with changed red card count
        ScoreChanged,                   //SCORE_CHANGED	Bet is submitted on a live soccer event with changed score
        TimeRestriction,                //TIME_RESTRICTION	Bet is submitted within too short of a period from the same bet previously placed by a client
        PastCutOffTime,                 //PAST_CUTOFFTIME	Bet is submitted on a game after the betting cutoff time
        AboveEventMax,                  //ABOVE_EVENT_MAX	Bet cannot be placed because client exceeded allowed maximum of risk on a line
        InvalidOddsFormat,              //INVALID_ODDS_FORMAT	If a bet was submitted with the odds format that is not allowed for the client
        ListedPitchersSelectionError    //LISTED_PITCHERS_SELECTION_ERROR	If bet was submitted with pitcher1MustStart and/or pitcher2MustStart parameters in Place Bet request with values that are not allowed.
    }
}
