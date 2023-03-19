Feature: NewRegistration

As a user on mybillafrica
I want to successfully register
So that i can use the website to pay bills

@tag1
Scenario: User register
	Given I navigate to mybillafrica homepage
	When I click the register button
	And I see the registration page
	And I select "United Kingdom" from the Registration country dropdown box
	And I select "Mr" from the the Title dropdown box
	And I enter "Tim" into the Firstname textbox
	Then [outcome]
