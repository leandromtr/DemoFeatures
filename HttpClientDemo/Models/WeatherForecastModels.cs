using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientDemo.Models
{
    public class WeatherForecastModels
    {
        public DayForecastModel[] Consolidated_weather { get; set; }
        public DateTime Sun_rise { get; set; }
        public DateTime Sun_set { get; set; }
        public string Title { get; set; }
        public string Timezone { get; set; }
    }

    //{
    //consolidated_weather: [
    //{
    //id: 6313953794719744,
    //weather_state_name: "Heavy Cloud",
    //weather_state_abbr: "hc",
    //wind_direction_compass: "WNW",
    //created: "2021-04-18T18:32:37.792569Z",
    //applicable_date: "2021-04-18",
    //min_temp: 7.925000000000001,
    //max_temp: 16.415,
    //the_temp: 15.89,
    //wind_speed: 4.613992418762428,
    //wind_direction: 284.8291554038729,
    //air_pressure: 1011.5,
    //humidity: 48,
    //visibility: 11.855451662292214,
    //predictability: 71
    //},
    //{
    //id: 5234299780464640,
    //weather_state_name: "Showers",
    //weather_state_abbr: "s",
    //wind_direction_compass: "WSW",
    //created: "2021-04-18T18:32:41.499740Z",
    //applicable_date: "2021-04-19",
    //min_temp: 9.055,
    //max_temp: 19.075,
    //the_temp: 17.28,
    //wind_speed: 4.090199275293618,
    //wind_direction: 249.83052680042675,
    //air_pressure: 1011.5,
    //humidity: 50,
    //visibility: 10.524163882923725,
    //predictability: 73
    //},
    //{
    //id: 4802710764257280,
    //weather_state_name: "Light Cloud",
    //weather_state_abbr: "lc",
    //wind_direction_compass: "WSW",
    //created: "2021-04-18T18:32:43.712477Z",
    //applicable_date: "2021-04-20",
    //min_temp: 10.379999999999999,
    //max_temp: 21.494999999999997,
    //the_temp: 19.475,
    //wind_speed: 6.7671266978445885,
    //wind_direction: 251.04508443142862,
    //air_pressure: 1016,
    //humidity: 44,
    //visibility: 13.533464566929133,
    //predictability: 70
    //},
    //{
    //id: 6515064933711872,
    //weather_state_name: "Heavy Rain",
    //weather_state_abbr: "hr",
    //wind_direction_compass: "SW",
    //created: "2021-04-18T18:32:46.584859Z",
    //applicable_date: "2021-04-21",
    //min_temp: 6.05,
    //max_temp: 20.439999999999998,
    //the_temp: 19.375,
    //wind_speed: 10.038105258288926,
    //wind_direction: 230.98774439863757,
    //air_pressure: 1005.5,
    //humidity: 56,
    //visibility: 9.734401097590073,
    //predictability: 77
    //},
    //{
    //id: 5194311118356480,
    //weather_state_name: "Heavy Cloud",
    //weather_state_abbr: "hc",
    //wind_direction_compass: "WNW",
    //created: "2021-04-18T18:32:50.581543Z",
    //applicable_date: "2021-04-22",
    //min_temp: 2.8899999999999997,
    //max_temp: 9.625,
    //the_temp: 9.45,
    //wind_speed: 12.20940775570137,
    //wind_direction: 285.1617390144437,
    //air_pressure: 1011.5,
    //humidity: 35,
    //visibility: 12.416860534478644,
    //predictability: 71
    //},
    //{
    //id: 5096656983818240,
    //weather_state_name: "Light Cloud",
    //weather_state_abbr: "lc",
    //wind_direction_compass: "WNW",
    //created: "2021-04-18T18:32:52.611690Z",
    //applicable_date: "2021-04-23",
    //min_temp: 5.14,
    //max_temp: 17.59,
    //the_temp: 11.41,
    //wind_speed: 7.473724449216576,
    //wind_direction: 282.5,
    //air_pressure: 1019,
    //humidity: 43,
    //visibility: 9.999726596675416,
    //predictability: 70
    //}
    //],
    //time: "2021-04-18T17:24:14.003133-04:00",
    //sun_rise: "2021-04-18T06:18:03.519756-04:00",
    //sun_set: "2021-04-18T19:42:25.994368-04:00",
    //timezone_name: "LMT",
    //parent:
    //{
    //title: "Pennsylvania",
    //location_type: "Region / State / Province",
    //woeid: 2347597,
    //latt_long: "40.994709,-77.604538"
    //},
    //sources:
    //[
    //{
    //title: "BBC",
    //slug: "bbc",
    //url: "http://www.bbc.co.uk/weather/",
    //crawl_rate: 360
    //},
    //{
    //title: "Forecast.io",
    //slug: "forecast-io",
    //url: "http://forecast.io/",
    //crawl_rate: 480
    //},
    //{
    //title: "HAMweather",
    //slug: "hamweather",
    //url: "http://www.hamweather.com/",
    //crawl_rate: 360
    //},
    //{
    //title: "Met Office",
    //slug: "met-office",
    //url: "http://www.metoffice.gov.uk/",
    //crawl_rate: 180
    //},
    //{
    //title: "OpenWeatherMap",
    //slug: "openweathermap",
    //url: "http://openweathermap.org/",
    //crawl_rate: 360
    //},
    //{
    //title: "World Weather Online",
    //slug: "world-weather-online",
    //url: "http://www.worldweatheronline.com/",
    //crawl_rate: 360
    //}
    //],
    //title: "Philadelphia",
    //location_type: "City",
    //woeid: 2471217,
    //latt_long: "39.952271,-75.162369",
    //timezone: "US/Eastern"
    //}
}
