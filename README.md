# ShipIt

The Most powerful ecommerce shipping site written in react

## Requirements

+ [Node.js](https://nodejs.org/)
+ [React](https://facebook.github.io/react/)
+ [.net 5](https://dotnet.microsoft.com/download/dotnet/5.0)
+ [git](https://git-scm.com/downloads)
+ [yarn](https://git-scm.com/downloads)

## Installation or Getting Started

### Run the server:
#### 1. Open a command shell
    > git clone https://github.com/mofoj0e/shipit.git
    > cd ShipIt\server\Closure.ECommerceShipping.Api\
    > dotnet run

### Run the client:
#### 1. Open another instance of the shell to run the client
#### 2. Navigate to the ShipIt directory
    > cd ShipIt\client\
    > yarn && yarn start


## Troubleshooting
On client, if you do not see any products rendered, this may be caused by a CORS error. You can try to install a CORS extension from chrome web store.
https://chrome.google.com/webstore/detail/allow-cors-access-control/lhobafahddgcelffkeicbaginigeejlf

## Running Tests

#### Navigate to ShipIt project directory:
    > cd server\Tests\
    > dotnet test -v n

## Some notes

I am using a library called Redux Toolkit which allows me to write reducers in a mutable way. It also removes a lot of boiler plate code.
