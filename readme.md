# People Search for Health Catalyst

This is a full stack (.netcore api, entityframework, Angular) implementation of a page which allows a user to search for a person. This is built on top of the sample angular project so the default pages are still used.

### Prerequisites

I believe you need node and npm installed globally. Everything else should be obtainable using a nuget package restore 

### Installing

Clone the repo. 
Open in Visual Studio 2017 

End with an example of getting some data out of the system or using it for a little demo

## Running the tests

There are angular instantiation tests which are runnable via the command line (ng test)
as well as an XUnit Unit Tests project

## Running the application

Right click the solution and select multiple startup projects. Select both PeopleSearch.API and PeapleSearch.UI

## Deployment

Not contemplated --- at this point it only uses an in memory (and very ugly database)

## Built With

* [Angular](http://www.angular.io) - The web framework used
* Visual Studio 2017

## Authors

* **Matthew Anderson** - *Initial work* 

## License

This project is not licensed.

## Tools used

* Visual Studio 2017 Community Edition
* WebStorm 
* Postman
* XUnit
* Karma
* Adobe Photoshop

## Wishlist for next version
* Much better database - This version is a single table. In future I would break out the interests into their own table (probably). I also cheated on the address there is no city state or zip
* Strip out the values controller, repository and model classes
* Allow for the user to add a person
 