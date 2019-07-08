import React, { Component } from "react";
import { Text, View, Image, StyleSheet, FlatList } from "react-native";
import axios from "axios";
import api from "../services/api";
import { AsyncStorage } from 'react-native';

class Main extends Component {

    static navigationOptions = {
        tabBarIcon: ({ tintColor }) => (
            <Image
                source={require("../assets/Logo-FixBi.png")}
                style={styles.iconeNavegacaoAtendimentos}
            />
        )
    };

    constructor(props) {
        super(props);
        this.state = {
            Atendimentos: []
        };
    }

    componentDidMount() {
        this.carregarAtendimentos();
    }

    carregarAtendimentos = async () => {
        let token = await AsyncStorage.getItem('userToken');

        const resposta = await api.get("/atendimentos/listar", {
            headers: {
                "Content-Type": "application/json",
                'Authorization': "Bearer " + token
            }
        });
        const dadosDaApi = resposta.data;
        this.setState({ Atendimentos: dadosDaApi });
    };

    render() {
        return (

            <View style={styles.telaAtendimentos}>

                    <Image
                        source={require('../assets/Logo-FixBi.png')}
                        style={styles.imagemAtendimentos}
                    />

                    <Text style={styles.textoAtendimentos}>{"Veja seus atendimentos"}</Text>

                    <FlatList
                        data={this.state.Atendimentos}
                        keyExtractor={item => item.idAtendimento}
                        renderItem={this.renderizaItem}
                    />

            </View>
        );
    }

    renderizaItem = ({ item }) => (
        <View>

            <Text style={styles.textoListaAtendimentos}>Ciclista:</Text>
            <Text style={styles.textoListaAtendimentos}>{item.idCiclista}</Text>

            <Text style={styles.textoListaAtendimentos}>Data do atendimento:</Text>
            <Text style={styles.textoListaAtendimentos}>{item.dataHorario}</Text>

            <Text style={styles.textoListaAtendimentos}>Descrição:</Text>
            <Text style={styles.textoListaAtendimentos}>{item.descricaoAtendimento}</Text>

            <Text style={styles.textoListaAtendimentos}>Situação:</Text>
            <Text style={styles.textoListaAtendimentos}>{item.situacaoAtendimento}</Text>

            <Text style={styles.textoListaAtendimentos}>Nome do Mecânico:</Text>
            <Text style={styles.textoListaAtendimentos}>{item.idMecanico}</Text>

        </View>
    );
}

const styles = StyleSheet.create({

    telaAtendimentos: {
        flex: 1,
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "space-between",
    },

    imagemAtendimentos: {
        height: 120,
        width: 120,
    },

    textoAtendimentos: {
        fontSize: 40,
        fontFamily: "Arial",
        alignContent: "center",
        color: "#1E3D93",
    },

    textoListaAtendimentos: {
        fontSize: 22,
        fontFamily: "Arial",
        color: "#1E3D93",
        alignContent: "center",
    },

    iconeNavegacaoAtendimentos: {
        width: 25,
        height: 25,
    },

});

export default Main;