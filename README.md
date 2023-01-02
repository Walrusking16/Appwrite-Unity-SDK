# Appwrite Unity SDK

The Appwrite Unity SDK makes it easy to integrate your Unity app with the Appwrite API to start interacting with all
Appwrite features.

> **Warning**
> This SDK is still in beta and is not production ready. Please use with caution.

## Getting Started

### Add the SDK to your project

#### Using Unity Package Manager

1. Open your project in Unity
2. Open the Package Manager (Window > Package Manager)
3. Click the "+" button in the top left corner
4. Select "Add package from git URL..."
5. Paste the following URL:
6. Click "Add"
7. You're done!

#### Using the Unity Asset Store

1. Open your project in Unity
2. Open the Asset Store (Window > Asset Store)
3. Search for "Appwrite"
4. Click "Import"
5. You're done!

### Initialize the SDK

```csharp
```

### Planned Features

- [ ] Documentation
- [ ] Examples
- [ ] Editor Tools
- [ ] Account
    - [ ] Create Account
    - [ ] Create Email Session
    - [ ] Create OAuth2 Session
    - [ ] Create Magic URL Session
    - [ ] Create Magic URL Session (Confirmation)
    - [ ] Create Phone Session
    - [ ] Create Phone Session (Confirmation)
    - [ ] Create Anonymous Session
    - [ ] Create JWT
    - [ ] Get Account
    - [ ] Get Account Preferences
    - [ ] List Sessions
    - [ ] List Logs
    - [ ] Get Session
    - [ ] Update Name
    - [ ] Update Password
    - [ ] Update Email
    - [ ] Update Phone
    - [ ] Update Preferences
    - [ ] Update Status
    - [ ] Delete Session
    - [ ] Update OAuth Session (Refresh Tokens)
    - [ ] Delete Sessions
    - [ ] Create Password Recovery
    - [ ] Create Password Recovery (Confirmation)
    - [ ] Create Email Verification
    - [ ] Create Email Verification (Confirmation)
    - [ ] Create Phone Verification
    - [ ] Create Phone Verification (Confirmation)
- [ ] Teams
    - [ ] Create Team
    - [ ] List Teams
    - [ ] Get Team
    - [ ] Update Team
    - [ ] Delete Team
    - [ ] Create Team Memberships
    - [ ] List Team Memberships
    - [ ] Get Team Membership
    - [ ] Update Membership Roles
    - [ ] Update Team Membership Status
    - [ ] Delete Team Membership
- [ ] Database
    - [ ] Create Document
    - [x] List Documents
        - Partially implemented, does not support filters
    - [x] Get Document
    - [x] Update Document
        - Partially implemented, does not allow changing permissions
    - [ ] Delete Document
- [ ] Storage
    - [ ] Create File
    - [ ] List Files
    - [ ] Get File
    - [ ] Get File Preview
    - [ ] Get File for Download
    - [ ] Get File for View
    - [ ] Update File
    - [ ] Delete File
- [ ] Localization
    - [ ] Get User Locale
    - [ ] List Countries
    - [ ] List EU Countries
    - [ ] List Countries Phone Codes
    - [ ] List Continents
    - [ ] List Currencies
    - [ ] List Languages
- [ ] Avatars
    - [ ] Get Credit Card Icon
    - [ ] Get Browser Icon
    - [ ] Get Country Flag
    - [ ] Get Image from URL
    - [ ] Get Favicon
    - [ ] Get QR Code
    - [ ] Get User Initials
- [ ] Realtime
    - [ ] Connect
    - [ ] Subscribe
    - [ ] Unsubscribe
    - [ ] Publish
    - [ ] Disconnect