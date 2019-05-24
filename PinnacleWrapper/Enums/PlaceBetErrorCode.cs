using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PinnacleWrapper.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlaceBetErrorCode
    {
        ALL_BETTING_CLOSED,	                //Betting is not allowed at this moment
        ALL_LIVE_BETTING_CLOSED,	        //Live betting is not allowed at this moment
        BLOCKED_CLIENT,	                    //Client is no longer active
        INVALID_COUNTRY,	                //Client country is not allowed for betting
        BLOCKED_BETTING,	                //Not allowed betting for the client
        INVALID_EVENT,	                    //Invalid eventid
        ABOVE_MAX_BET_AMOUNT,	            //Stake is above allowed maximum amount
        BELOW_MIN_BET_AMOUNT,	            //Stake is below allowed minimum amount
        OFFLINE_EVENT,	                    //Bet is submitted on a event that is offline
        INSUFFICIENT_FUNDS,	                //Bet is submitted by a client with insufficient funds
        LINE_CHANGED,	                    //Bet is submitted on a line that has changed
        RED_CARDS_CHANGED,	                //Bet is submitted on a live soccer event with changed red card count
        SCORE_CHANGED,	                    //Bet is submitted on a live soccer event with changed score
        TIME_RESTRICTION,	                //Bet is submitted within too short of a period from the same bet previously placed by a client
        PAST_CUTOFFTIME,	                //Bet is submitted on a game after the betting cutoff time
        ABOVE_EVENT_MAX,	                //Bet cannot be placed because client exceeded allowed maximum of risk on a line
        INVALID_ODDS_FORMAT,	            //If a bet was submitted with the odds format that is not allowed for the client
        LISTED_PITCHERS_SELECTION_ERROR,	//If bet was submitted with pitcher1MustStart and/or pitcher2MustStart parameters in Place Bet request with values that are not allowed.
    }
}
