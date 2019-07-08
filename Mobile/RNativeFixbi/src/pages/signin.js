import React, { Component } from "react";
import {
  StyleSheet,
  View,
  Text,
  Image,
  TextInput,
  TouchableOpacity,
} from "react-native";

import { AsyncStorage } from 'react-native';
import api from "../services/api";

class SignIn extends Component {
  static navigationOptions = {
    header: null
  };

  constructor(props) {
    super(props);
    this.state = { email: "", senha: "" };
  }

  _realizarLogin = async () => {

    const resposta = await api.post("/login", {
      email: this.state.email,
      senha: this.state.senha
    });

    const token = resposta.data.token;
    await AsyncStorage.setItem("userToken", token);
    this.props.navigation.navigate("MainNavigator");
  };

  render() {
    return (

      <View style={styles.telaLogin}>

        <Image
          source={require('../assets/Logo-FixBi.png')}
          style={styles.imagemLogin}
        />
        <Text style={styles.textoLogin}>{"Fixbi"}</Text>
        
        <Text style={styles.textoLogin2}>{"Sua bike pronta em uma hora"}</Text>

        <TextInput
          style={styles.inputLogin}
          placeholder="usuario@fixbi.com"
          onChangeText={email => this.setState({ email })}
        />

        <TextInput
          style={styles.inputLogin}
          placeholder="******"
          secureTextEntry={true}
          onChangeText={senha => this.setState({ senha })}
        />

        <TouchableOpacity style={styles.botaoLogin}
          onPress={this._realizarLogin}>
          <Text style={styles.botaoLoginTexto}>Entrar</Text>
        </TouchableOpacity>

      </View>
    );
  }
}

const styles = StyleSheet.create({

  telaLogin: {
    flex: 1,
    flexDirection: "column",
    alignItems: "center",
    justifyContent: "space-around",
  },

  textoLogin: {
    fontSize: 45,
    fontFamily: "Arial",
    color: "#1E3D93",
    fontWeight: 'bold',
  },

  textoLogin2: {
    fontSize: 28,
    fontFamily: "Arial",
    color: "#1E3D93",
    fontWeight: 'bold',
  },

  imagemLogin: {
    height: 170,
    width: 170,
  },

  botaoLogin: {
    height: 50,
    elevation: 3,
    width: 300,
    borderWidth: 1,
    borderColor: "#1E3D93",
    backgroundColor: "#1E3D93",
    justifyContent: "center",
    alignItems: "center",
    borderRadius: 30
  },

  botaoLoginTexto: {
    fontSize: 28,
    fontFamily: "Arial",
    color: "white"
  },

  inputLogin: {
    alignItems: "center",
    borderWidth: 2,
    borderColor: "#1E3D93",
    color: "#1E3D93",
    width: 300,
    height: 50,
    fontSize: 28,
    fontFamily: "Arial",
    borderRadius: 30
  }
});

export default SignIn;