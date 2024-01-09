import org.example.JogoDaVelha;
import org.example.Casa;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.List;

public class JogoDaVelhaTest {


    private JogoDaVelha jogo = new JogoDaVelha();


    @Test
    void test3(){
        int[][] tabuleiro = new int[][] {
                {-1, -1, 0},
                {0, -1, 0},
                {1, 0, 1},
        };

        int player = 1;

        Assertions.assertEquals(List.of(new Casa(2, 1)), jogo.melhorJogada(tabuleiro, player));
    }

    @Test
    void test2(){
        int[][] tabuleiro = new int[][] {
                {-1, 0, 0},
                {0, -1, 0},
                {0, 0, 1},
        };

        int player = 1;

        Assertions.assertEquals(List.of(new Casa(0, 2), new Casa(2, 0)), jogo.melhorJogada(tabuleiro, player));
    }
}
