import androidx.compose.animation.AnimatedVisibility
import androidx.compose.foundation.Image
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.padding
import androidx.compose.material.Button
import androidx.compose.material.Divider
import androidx.compose.material.MaterialTheme
import androidx.compose.material.Text
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.unit.dp
import androidx.lifecycle.compose.collectAsStateWithLifecycle
import androidx.lifecycle.viewmodel.compose.viewModel
import org.jetbrains.compose.resources.painterResource
import org.jetbrains.compose.ui.tooling.preview.Preview

import greetingkmp.composeapp.generated.resources.Res
import greetingkmp.composeapp.generated.resources.compose_multiplatform

@Composable
@Preview
fun App(mainViewModel: MainViewModel = viewModel()) {
    MaterialTheme {
        var showContent by remember { mutableStateOf(false) }
        val greetings by mainViewModel.greetingList.collectAsStateWithLifecycle()
        Column(Modifier.fillMaxWidth(), horizontalAlignment = Alignment.CenterHorizontally) {
            Button(onClick = { showContent = !showContent }) {
                Text("Click me!")
            }
            AnimatedVisibility(showContent) {
                Column(
                    modifier = Modifier.padding(all = 20.dp),
                    verticalArrangement = Arrangement.spacedBy(8.dp)
                ) {
                    Image(painterResource(Res.drawable.compose_multiplatform), null)
                    greetings.forEach { greeting ->
                        Text(greeting)
                        Divider()
                    }
                }
            }
        }
    }
}