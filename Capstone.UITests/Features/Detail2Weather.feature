Feature: Detail2Weather
	When on a park's detail page, I want to be able to see that park's weather forecast.

@mytag
Scenario: Add two numbers
	Given I am on a park's detail page
	When I click the forecasts link
	Then I should be taken to that park's weather forecast page.
