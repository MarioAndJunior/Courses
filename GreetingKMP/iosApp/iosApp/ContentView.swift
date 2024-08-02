import SwiftUI
import Shared
import KMPNativeCoroutinesCore
import KMPNativeCoroutinesAsync


struct ContentView: View {
    @State private var showContent = false
    @ObservedObject private(set) var viewModel: ViewModel
    var body: some View {
        VStack {
            Button("Click me!") {
                withAnimation {
                    showContent = !showContent
                }
            }

            if showContent {
                VStack(spacing: 16) {
                    Image(systemName: "swift")
                        .font(.system(size: 200))
                        .foregroundColor(.accentColor)
//                    let phrases = Greeting().greet()
//                    List(phrases, id: \.self) {
//                        Text($0)
//                    }
//                    Text("SwiftUI: \(Greeting().greet())")
                    ListView(phrases: viewModel.greetings)
                        .task {
                            await self.viewModel.startObserving()
                        }
                }
                .transition(.move(edge: .top).combined(with: .opacity))
            }
        }
        .frame(maxWidth: .infinity, maxHeight: .infinity, alignment: .top)
        .padding()
    }
}

extension ContentView {
    @MainActor
    class ViewModel: ObservableObject {
        @Published var greetings: Array<String> = []
        
        func startObserving() async {
            do {
                let sequence = asyncSequence(for: Greeting().greet())
                for try await phrase in sequence {
                    self.greetings.append(phrase)
                }
            } catch {
                print("Failed with error: \(error)")
            }
        }
    }
}

struct ListView: View {
    let phrases: Array<String>
    
    var body: some View {
        List(phrases, id: \.self) {
            Text($0)
        }
    }
}

struct ContentView_Previews: PreviewProvider {
    static var previews: some View {
        ContentView(viewModel: ContentView.ViewModel())
    }
}
