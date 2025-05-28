using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateConverter.Helpers
{
    public class Helper
    {
        public static string GetCountryCode(string countryName)
        {
            var customMapping = new Dictionary<string, string>
{
    { "Antigua & Barbuda", "AG" },
    { "Bosnia & Herzegovina", "BA" },
    { "Congo (Kinshasa)", "CD" },
    { "Congo (Brazzaville)", "CG" },
    { "Ivory Coast", "CI" },
    { "Korea North", "KP" },
    { "Korea South", "KR" },
    { "Laos", "LA" },
    { "Moldova", "MD" },
    { "Russia", "RU" },
    { "Taiwan", "TW" },
    { "Venezuela", "VE" },
    { "Vietnam", "VN" },
    { "St Helena & Tristan da Cunha", "SH" },
    { "St Kitts & Nevis", "KN" },
    { "St Lucia", "LC" },
    { "St Maarten", "SX" },
    { "St Pierre & Miquelon", "PM" },
    { "St Vincent & Grenadines", "VC" },
    { "DRC", "CD" },
    { "Gambia", "GM" },
    { "Sudan South", "SS" },
    { "Kosovo", "XK" }, // Kosovo ISO code is not universally recognized
    { "Cayman Islands", "KY" },
    { "Falkland Islands", "FK" },
    { "Gibraltar", "GI" },
    { "Montserrat", "MS" },
    { "Pitcairn Islands", "PN" },
    { "Virgin Islands UK", "VG" },
    { "Virgin Islands US", "VI" },
    { "Turks & Caicos", "TC" },
    { "Samoa US", "AS" },
    { "Samoa West", "WS" },
    { "Diego Garcia", "IO" },
    { "Antarctica", "AQ" },
    { "Cocos Islands", "CC" },
    { "Cook Islands", "CK" },
    { "Faroe Islands", "FO" },
    { "French Polynesia", "PF" },
    { "Greenland", "GL" },
    { "Guadeloupe", "GP" },
    { "Martinique", "MQ" },
    { "Mayotte", "YT" },
    { "New Caledonia", "NC" },
    { "Reunion", "RE" },
    { "Saint Pierre and Miquelon", "PM" },
    { "Wallis & Futuna", "WF" },
    { "Ascension Island", "AC" },
    { "Bolivia", "BO" },
    { "Brunei", "BN" },
    { "Cape Verde", "CV" },
    { "Cyprus North", "CY" }, // No separate ISO code for Northern Cyprus
    { "Czech Republic", "CZ" },
    { "East Timor", "TL" },
    { "Fiji Islands", "FJ" },
    { "Grenada (incl Carriacou)", "GD" },
    { "Guinea Bissau", "GW" },
    { "Iran", "IR" },
    { "Macau", "MO" },
    { "Macedonia", "MK" }, // Officially known as North Macedonia
    { "Micronesia", "FM" }, // Federated States of Micronesia
    { "Netherlands Antilles", "AN" }, // Code for Netherlands Antilles, no longer officially assigned
    { "Palestine", "PS" },
    { "Saipan", "MP" }, // Saipan is part of the Northern Mariana Islands
    { "Sao Tome", "ST" }, // São Tomé and Príncipe
    { "Swaziland", "SZ" }, // Officially known as Eswatini
    { "Syria", "SY" },
    { "Tanzania", "TZ" },
    { "Thuraya", null }, // Thuraya is a satellite phone network, not a country
    { "Trinidad & Tobago", "TT" },
    { "Turkey", "TR" },
    { "UK", "GB" },
    { "USA", "US" },
    { "Congo", "CG" },
    { "Vatican", "VA" }
};
            if (customMapping.ContainsKey(countryName))
                return customMapping[countryName];
            else return "";
       
        }
    }
}
