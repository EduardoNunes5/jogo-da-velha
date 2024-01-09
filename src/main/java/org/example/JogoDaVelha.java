package org.example;

import java.util.ArrayList;
import java.util.List;

public class JogoDaVelha {

    public List<Casa> melhorJogada(int[][] tabuleiro, int jogador){
        List<Casa> casas = new ArrayList<>();

        for(int i = 0; i < 3; i++){
            for(int j = 0; j < 3; j++){
                if(tabuleiro[i][j] == 0){
                    casas.add(new Casa(i,j));
                }
            }
        }

        List<Casa> resultado = new ArrayList<>();
        for(Casa casa : casas){
            int somaAdjacente = 0;
            if(casa.linha() == 0 && casa.coluna() == 0){
                somaAdjacente += tabuleiro[casa.linha()][casa.coluna() +1];
                somaAdjacente += tabuleiro[casa.linha()][casa.coluna() + 2];
                somaAdjacente += tabuleiro[1][casa.coluna()];
                somaAdjacente += tabuleiro[2][casa.coluna()];

                if(tabuleiro[casa.linha()][casa.coluna() +1] != 0 && tabuleiro[casa.linha()][casa.coluna() + 2] != 0 && tabuleiro[1][casa.coluna()] != 0 && tabuleiro[2][casa.coluna()] != 0 && somaAdjacente == 0){
                    resultado.add(new Casa(casa.linha(), casa.coluna()));
                    break;
                }
            }
            else if(casa.linha() == 0 && casa.coluna() == 1){
                somaAdjacente += tabuleiro[casa.linha()][casa.coluna() + 1];
                somaAdjacente += tabuleiro[casa.linha()][casa.coluna() - 1];
                somaAdjacente += tabuleiro[1][casa.coluna()];
                somaAdjacente += tabuleiro[2][casa.coluna()];

                if(tabuleiro[casa.linha()][casa.coluna() + 1] != 0 && tabuleiro[casa.linha()][casa.coluna() - 1] != 0 && tabuleiro[1][casa.coluna()] != 0 &&  tabuleiro[2][casa.coluna()] != 0 && somaAdjacente == 0){
                    resultado.add(new Casa(casa.linha(), casa.coluna()));
                    break;
                }
            }
            else if(casa.linha() == 0 && casa.coluna() == 2){
                somaAdjacente += tabuleiro[casa.linha()][casa.coluna() - 1];
                somaAdjacente += tabuleiro[casa.linha()][casa.coluna() -  2];
                somaAdjacente += tabuleiro[1][casa.coluna() - 1];
                somaAdjacente += tabuleiro[2][casa.coluna() - 2];
                somaAdjacente += tabuleiro[1][casa.coluna()];
                somaAdjacente += tabuleiro[2][casa.coluna()];

                if(tabuleiro[casa.linha()][casa.coluna() - 1] != 0 && tabuleiro[casa.linha()][casa.coluna() -  2] != 0 && tabuleiro[1][casa.coluna() - 1] != 0 && tabuleiro[2][casa.coluna() - 2] != 0 &&
                        tabuleiro[1][casa.coluna()] != 0 &&  tabuleiro[2][casa.coluna()] != 0 && somaAdjacente == 0
                ){
                    resultado.add(new Casa(casa.linha(), casa.coluna()));
                    break;
                }

            }
            else if(casa.linha() == 1 && casa.coluna() == 0){
                somaAdjacente += tabuleiro[0][0];
                somaAdjacente += tabuleiro[2][0];
                somaAdjacente += tabuleiro[1][1];
                somaAdjacente += tabuleiro[1][2];

                if(tabuleiro[0][0] != 0 && tabuleiro[2][0] != 0 && tabuleiro[1][1] != 0 && tabuleiro[1][2] != 0 && somaAdjacente == 0){
                    resultado.add(new Casa(casa.linha(), casa.coluna()));
                    break;
                }

            }
            else if(casa.linha() == 1 && casa.coluna() == 1){
                for(int i = 0; i < 3; i++){
                    for(int j = 0; j < 3; j++){
                        if(i != 1 && j != 1){
                            somaAdjacente += tabuleiro[i][j];
                        }
                    }
                }

            }
            else if(casa.linha() == 1 && casa.coluna() == 2){
                somaAdjacente += tabuleiro[1][1];
                somaAdjacente += tabuleiro[1][0];
                somaAdjacente += tabuleiro[2][2];
                somaAdjacente += tabuleiro[0][2];

                if(tabuleiro[1][1] != 0 && tabuleiro[1][0] != 0 && tabuleiro[2][2] != 0 && tabuleiro[0][2] != 0 && somaAdjacente == 0){
                    resultado.add(new Casa(casa.linha(), casa.coluna()));
                    break;
                }

            }
            else if(casa.linha() == 2 && casa.coluna() == 0){
                somaAdjacente += tabuleiro[0][0];
                somaAdjacente += tabuleiro[1][0];
                somaAdjacente += tabuleiro[1][1];
                somaAdjacente += tabuleiro[0][2];
                somaAdjacente += tabuleiro[2][1];
                somaAdjacente += tabuleiro[2][2];

                if(tabuleiro[0][0] != 0 && tabuleiro[1][0] != 0 && tabuleiro[1][1] != 0 && tabuleiro[0][2] != 0 && tabuleiro[2][1] != 0 && tabuleiro[2][2] != 0 && somaAdjacente == 0){
                    resultado.add(new Casa(casa.linha(), casa.coluna()));
                    break;
                }

            }

            else if(casa.linha() == 2 && casa.coluna() == 1){
                somaAdjacente += tabuleiro[1][1];
                somaAdjacente += tabuleiro[0][1];
                somaAdjacente += tabuleiro[2][0];
                somaAdjacente += tabuleiro[2][2];

                if(tabuleiro[1][1] != 0 && tabuleiro[0][1] !=0 && tabuleiro[2][0] != 0 && tabuleiro[2][2] !=0 && somaAdjacente == 0){
                    resultado.add(new Casa(casa.linha(), casa.coluna()));
                    break;
                }
            }

            else if(casa.linha() == 2 && casa.coluna() == 2){
                somaAdjacente += tabuleiro[2][1];
                somaAdjacente += tabuleiro[2][0];
                somaAdjacente += tabuleiro[1][1];
                somaAdjacente += tabuleiro[0][0];
                somaAdjacente += tabuleiro[1][2];
                somaAdjacente += tabuleiro[0][2];

                if(tabuleiro[2][1] != 0 && tabuleiro[2][0] != 0 && tabuleiro[1][1] != 0 && tabuleiro[0][0] != 0 && tabuleiro[1][2] != 0 && tabuleiro[0][2] != 0 && somaAdjacente == 0){
                    resultado.add(new Casa(casa.linha(), casa.coluna()));
                    break;
                }

            }

            if(somaAdjacente == -1){
                resultado.add(new Casa(casa.linha(), casa.coluna()));
            }
            else if(somaAdjacente == 1){
                resultado.add(new Casa(casa.linha(), casa.coluna()));
            }

            somaAdjacente = 0;
        }

        return resultado;
    }


}
