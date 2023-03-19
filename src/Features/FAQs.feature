Feature: FAQs

As a user of MyBillAfrica

I want to be able to navigate to the Help Page

So that I can see the FAQs

https://mjtraining.atlassian.net/browse/MT-3?atlOrigin=eyJpIjoiMjgzYzE4ZjhkOTRmNDY0NDlkNTFiNWI2MzM1ZjZmNzkiLCJwIjoiaiJ9

@tag1
Scenario: As a validated user of My Bill Africa
	Given I can navigate to the FAQs Page 
	When I click on each question button
	Then The appropriate text is revealed
