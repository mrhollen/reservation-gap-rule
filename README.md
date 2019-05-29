[![Build Status](https://travis-ci.com/mrhollen/reservation-gap-rule.svg?branch=master)](https://travis-ci.com/mrhollen/reservation-gap-rule)

# Reservation Gap Rule Demonstration
This project is a web api written in C# .Net Core to show processing of the "Gap Rule" whereby a reservation for for a hotel room or other resource cannot leave a gap of a specified length before or after the time reserved.

### Technologies Used
For this I used C# .Net Core because it's what I'm most familiar with and it's cross-platform so lends itself to containerization easliy.

### How to Use
The project is made to be a REST API run in a docker container. In the project root you should find a dockerfile. To make life easy I've included the docker commands below (if on linux they may require sudo): 

`docker build -t reservation-gap-rule .`

`docker run --rm -p 8080:8080 reservation-gap-rule`

After the container is built and running, make an POST request to:

`http://[ipaddress]:8080/api/reservation/check`

The body of the POST request must contain the json text from the file supplied in the project specificaitons. A copy has been provided in the project root called `test-case.json`

### Overview
For this project my solution was to break different problems down into smaller solvable problems. For example, I wrote a method that checks if two dates are far enough appart or close enough together as to not create an 'illigal' gap between them. I also wrote a method to quickly check whether two date ranges overlapped. These are both used when trying to find the available campsites. To store the reservations I used a sorted list. This allows fast searching using a binary search with a speed of O(logN). The solution I used stored all the data in memory, but could be easily adapted to be stored in a database of some sort.

### Considerations
While the project specification was that only a 1 day gap should be considered, I tried to write the program in such a way that any length 'illigal' gap could be requested. In the real world, the REST API would also not trust the data coming from the client, so any data the client sent regarding past reservations or campsites would be disregarded in favor of the backend maintained data. This would just mean that the request model would only contain the dates being searched for.

### Assumptions
I only really made one assumption in this project. That is, I assumed a campsite would be occupied for the whole day and then vacated at the end of the day. Therefore, you could not have one group leave a campsite on a day, and then have another group move into it that same day. In the code this means that if two date ranges touch, they are considered to be overlapping. This could be changed so that a reservation could end at 10am and a new one could start at 1pm or whatever is needed.
