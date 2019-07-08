import {createStackNavigator, 
    createBottomTabNavigator, 
    createAppContainer,
    createSwitchNavigator} 
    from "react-navigation";

import Main from "./pages/main";
import Profile from "./pages/profile";
import SignIn from "./pages/signin";

const AuthStack = createStackNavigator({SignIn});

const MainNavigator = createBottomTabNavigator({
    Main,
    Profile
},
{

swipeEnabled: true,
tabBarOptions: {
    showLabel: false,
    showIcon: true,
    inactiveBackgroundColor: "#1E3D93",
    activeBackgroundColor: "#1E3D93",
    activeTintColor: "#ffffff",
    inactiveTintColor: "#ffffff",
    style:{
        height: 50
    }
}
}
);

export default createAppContainer(
    createSwitchNavigator(
        {
            MainNavigator,
            AuthStack
        },
        {initialRouteName: "AuthStack"}
    )
    );