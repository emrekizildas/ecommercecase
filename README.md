# ecommercecase
e-Commerce console application.

## Logic:
* A fixed database is run with the application.
* Each campaign and product can have only one of the same name.
* A campaign can be created for a product.
* During a campaign; If the product sales are more than half of the target, it is increased.
* During a campaign; If the product sales are less than half of the target, a discount is made.
* Products whose prices change during a campaign return to their main prices upon the end of the campaign.

## Technology / methods used:
* Event-Driven-Development
* Unit tests (some, little)
* Domain modeling
* Error Handling
* Centralize Error Middleware
* .Net Core 3.1
