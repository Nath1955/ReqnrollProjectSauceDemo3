Feature: Login

As a user, I would like to login and add two products in the cart.

@Login
Scenario: Valid Login Test
	Given user navigate on saucedemo website
	    When user enters login credentials
	    | username       | password      |
	    | standard_user  | secret_sauce  |
	    And user click on the login button
        Then user lands on the current url with 'inventory'
        And user is on product's page
    When user adds one of the following product to the cart:
        | ProductName          |
        | Sauce Labs Backpack  |
        | Sauce Labs Onesie    |
        And user clicks on cart basket to view the items
    Then user verifies product count is 2
        And user also verifies the product names to be:
        | ProductName         |
        | Sauce Labs Backpack |
        | Sauce Labs Onesie   |
     When user click on the hambuger menu
	   And user click on logout button
     Then user should logout

  

    

