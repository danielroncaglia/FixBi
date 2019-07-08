import React, { Component } from 'react';
import { Text, Image, StyleSheet, View, TouchableOpacity, AsyncStorage } from "react-native";
import api from '../services/api'
import jwt from 'jwt-decode';

class Profile extends Component {

    static navigationOptions = {
        tabBarIcon: ({ tintColor }) => (
            <Image
                source={require("../assets/perfil.png")}
                style={styles.iconeNavegacaoPerfil}
            />
        )
    };

    constructor(props) {
        super(props);
        this.state = {
            idCiclista: ""
            , idMecanico: ""
            , dataHorario: ""
            , descricaoAtendimento: ""
            , situacaoAtendimento: ""
        }
    }

    cadastrarAtendimento = async () => {

        const resposta = await api.post("/atendimentos/cadastrar", {
            idCiclista: this.state.idCiclista,
            idMecanico: this.state.idMecanico,
            dataHorario: this.state.dataHorario,
            descricaoAtendimento: this.state.descricaoAtendimento,
            situacaoAtendimento: this.state.situacaoAtendimento,
        });
        console.warn(resposta);

    }
    buscardados = async () => {
        try {
            const value = await AsyncStorage.getItem("Aplicativo.Fixbi");
            if (value !== null) {
                this.setState({ IdUsuario: jwt(value).Id })
                this.setState({ token: value })
                console.warn(value);
            }
        } catch (error) {

        }

    }
    componentDidMount() {
        this.buscardados();
    }

    render() {
        return (

            <View style={styles.telaCadastrar}>

                <Image
                    source={require('../assets/Logo-FixBi.png')}
                    style={styles.imagemCadastrar}
                />

                <Text style={styles.textoCadastrar}>{"Peça um atendimento"}</Text>

                <TextInput
                    style={styles.inputCadastrar}
                    placeholder="ID Ciclista"
                    onChangeText={idCiclista => this.setState({ idCiclista })}
                />

                <TextInput
                    style={styles.inputCadastrar}
                    placeholder="ID Mecanico"
                    onChangeText={idMecanico => this.setState({ idMecanico })}
                />

                <TextInput
                    style={styles.inputCadastrar}
                    placeholder="Data Horário"
                    onChangeText={dataHorario => this.setState({ dataHorario })}
                />

                <TextInput
                    style={styles.inputCadastrar}
                    placeholder="Descrição"
                    onChangeText={descricaoAtendimento => this.setState({ descricaoAtendimento })}
                />

                <TextInput
                    style={styles.inputCadastrar}
                    placeholder="Situação"
                    onChangeText={situacaoAtendimento => this.setState({ situacaoAtendimento })}
                />

                <TouchableOpacity
                    style={styles.botaoCadastrar}
                    onPress={this.cadastrarAtendimento}
                >
                    <Text style={styles.botaoTextoCadastrar}>Cadastrar</Text>

                </TouchableOpacity>

            </View>
        );
    }
};

const styles = StyleSheet.create({


    telaCadastrar: {
        flex: 1,
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "space-around",
    },

    textoCadastrar: {
        fontSize: 45,
        fontFamily: "Arial",
        color: "#1E3D93",
        fontWeight: 'bold',
    },

    imagemCadastrar: {
        height: 170,
        width: 170,
    },

    botaoCadastrar: {
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

    botaoTextoCadastrar: {
        fontSize: 28,
        fontFamily: "Arial",
        color: "white"
    },

    inputCadastrar: {
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

export default Profile;
