Feature: GuestLogin

As a user
I want to login to mybillafrica
using the guest pass

@tag1
Scenario: Login with valid guest Pass
	Given I am on the mybillafrica guest access page
	When I enter my guest password
	Then I should be taken to the homepage

