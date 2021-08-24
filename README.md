# RocketLandingControlSystem
Rocket Landing Control System Library

# Run Project
1- Run Console App To See Three Requests For Landing With (Ok , Out Of Range , Clash ) Status
2- Run Tests In  Test Project TO Check All Cases



# How To Use Library
- add reference to project in any ui project or console project (api or console app)
```
// create controller instance
var rocketController = new RocketLandingController();
// request for landing request with coorinates (give OK)
var rocketOneRequest = controller.CreateNewRequest(5 , 5);
// request for landing request with coorinates (give Clash With Previous Location)
// as this requests pre cheked location by another rocket
var rocketTwoRequest = controller.CreateNewRequest(5 , 5);
// request for landing request with coorinates (give Out Of Platform Range)
// because platofrm default size is 10 * 10 and this is 13 * 15
var rocketThreeRequest = controller.CreateNewRequest(13 , 15);
```

- to use coordination
```
var coordination = new Coordination(6, 6);
var rocketFourRequest = controller.ProcessRequestForLanding(coordination);
```
