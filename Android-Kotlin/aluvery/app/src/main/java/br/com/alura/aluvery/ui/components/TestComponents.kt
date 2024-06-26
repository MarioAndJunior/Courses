package br.com.alura.aluvery.ui.components

import android.content.res.Configuration
import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxHeight
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.material3.Surface
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.dp
import br.com.alura.aluvery.ui.theme.AluveryTheme

@Composable
fun MyFirstComposable() {
    Text(text = "Meu primeiro Texto")
    Text(text = "Meu primeiro texto maior")
}

@Composable
@Preview(
    name = "New Text preview",
    uiMode = Configuration.UI_MODE_NIGHT_YES
)
@Preview(name = "New Text preview")
fun MyFirstComposablePreview() {
    AluveryTheme {
        Surface {
            MyFirstComposable()
        }
    }
}

@Preview(showBackground = true)
@Composable
fun ColumnPreview() {
    Column {
        Text(text = "Texto 1")
        Text(text = "Texto 2")
    }
}

@Preview(showBackground = true)
@Composable
fun RowPreview() {
    Row {
        Text(text = "Texto 1")
        Text(text = "Texto 2")
    }
}

@Preview(showBackground = true)
@Composable
fun BoxPreview() {
    Box {
        Text(text = "Texto 1")
        Text(text = "Texto 2")
    }
}

@Preview(showBackground = true)
@Composable
fun CustomLayoutPreview() {
    Column(
        Modifier
            .padding(all = 8.dp)
            .background(Color.Blue)
            .padding(8.dp)
            .fillMaxWidth()
            .fillMaxHeight()
    ) {
        Text(text = "Texto 1")
        Text(text = "Texto 2")
        Row(
            modifier = Modifier
                .padding(
                    horizontal = 8.dp,
                    vertical = 16.dp
                )
                .background(color = Color.Green)
                .fillMaxWidth()
        ) {
            Text(text = "Texto 3")
            Text(text = "Texto 4")
        }

        Box(
            modifier = Modifier
                .padding(
                    horizontal = 8.dp,
                    vertical = 16.dp
                )
                .background(color = Color.Red)
        ) {
            Row(
                modifier = Modifier
                    .padding(
                        horizontal = 8.dp,
                        vertical = 16.dp
                    )
                    .background(color = Color.Cyan)
                    .fillMaxWidth(0.9f)
            ) {
                Text(text = "Texto 7")
                Text(text = "Texto 8")
            }

            Column(
                modifier = Modifier
                    .padding(
                        horizontal = 8.dp,
                        vertical = 16.dp
                    )
                    .background(color = Color.Yellow)
            ) {
                Text(text = "Texto 5")
                Text(text = "Texto 6")
            }
        }
    }
}