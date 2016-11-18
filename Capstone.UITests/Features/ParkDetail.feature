Feature: ParkDetail
	Make sure the details shown on detail page are from park requested


Scenario: Click on Image
	Given I am on the ParkLists page
	When I click on an image
	Then the result should be the detail page of that park
