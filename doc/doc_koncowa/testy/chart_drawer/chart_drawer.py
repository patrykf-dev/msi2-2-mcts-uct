import matplotlib.pyplot as plt
import pandas as pd
import seaborn as sns

iterations = [100, 500, 1000, 2500, 5000, 7500, 10000, 12500, 15000, 17500, 20000]
ucb1 = [-0.405714286, -0.083428571, 0.206857143, 0.437714286, 0.501714286, 0.379428571, 0.353142857, 0.565714286,
        0.554285714, 0.481142857, 0.491428571]
ucbm = [-0.381714286, -0.04, -0.066285714, 0.108571429, -0.275428571, -0.267428571, -0.190857143, -0.264, 0.012571429,
        -0.056, -0.030857143]
ucbv = [-0.133714286, -0.210285714, -0.011428571, 0.336, 0.388571429, 0.194285714, 0.381714286, 0.277714286, 0.56,
        0.406857143, 0.356571429]


X_LABEL = 'Liczba iteracji'
Y_LABEL = 'Ocena'
def show_chart():


    df = pd.DataFrame({
        X_LABEL: iterations,
        'UCB1': ucb1,
        'UCBM': ucbm,
        'UCBV': ucbv
    })
    sns.set_style("whitegrid")
    df = df.melt(X_LABEL, var_name='Legenda', value_name=Y_LABEL)
    sns.set(rc={'figure.figsize': (12, 6)})
    graph = sns.lineplot(data=df, x=X_LABEL, y=Y_LABEL, hue='Legenda', marker='o', markersize=8)
    graph.axhline(0, color='black')
    plt.legend(["UCB1", "UCB-Minimal", "UCB-V"])

    plt.show()
    fig = graph.get_figure()
    fig.savefig("iterations.eps")


if __name__ == '__main__':
    show_chart()

