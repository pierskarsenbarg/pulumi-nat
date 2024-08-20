package main

import (
	"fmt"
	"os"

	"github.com/pierskarsenbarg/pulumi-fcknat/pkg"
	p "github.com/pulumi/pulumi-go-provider"
	"github.com/pulumi/pulumi-go-provider/infer"
	"github.com/pulumi/pulumi-go-provider/middleware/schema"
	dotnetgen "github.com/pulumi/pulumi/pkg/v3/codegen/dotnet"
	gogen "github.com/pulumi/pulumi/pkg/v3/codegen/go"
	nodejsgen "github.com/pulumi/pulumi/pkg/v3/codegen/nodejs"
	pythongen "github.com/pulumi/pulumi/pkg/v3/codegen/python"
	"github.com/pulumi/pulumi/sdk/v3/go/common/tokens"
)

func main() {
	err := p.RunProvider("fcknat", "0.1.0", provider())
	if err != nil {
		fmt.Fprintf(os.Stderr, "Error: %s", err.Error())
		os.Exit(1)
	}
}

func provider() p.Provider {
	return infer.Provider(infer.Options{
		Metadata: schema.Metadata{
			DisplayName: "fcknat",
			Description: "Pulumi Component to create a FCK-NAT based nat gateway",
			LanguageMap: map[string]any{
				"go": gogen.GoPackageInfo{
					ImportBasePath: "github.com/pierskarsenbarg/pulumi-fcknat/sdk/go/fcknat",
				},
				"nodejs": nodejsgen.NodePackageInfo{
					PackageName: "@pierskarsenbarg/fcknat",
					Dependencies: map[string]string{
						"@pulumi/pulumi": "^3.0.0",
						"@pulumi/aws": "^6.48.0",
					},
					DevDependencies: map[string]string{
						"@types/node": "^10.0.0", // so we can access strongly typed node definitions.
						"@types/mime": "^2.0.0",
					},
				},
				"csharp": dotnetgen.CSharpPackageInfo{
					RootNamespace: "PiersKarsenbarg",
					PackageReferences: map[string]string{
						"Pulumi": "3.*",
						"Pulumi.Aws": "6.*",
					},
				},
				"python": pythongen.PackageInfo{
					Requires: map[string]string{
						"pulumi": ">=3.0.0,<4.0.0",
						"pulumi-aws": ">=6.0.0,<7.0.0",
					},
					PackageName: "pierskarsenbarg_pulumi_fcknat",
				},
			},
			PluginDownloadURL: "github://api.github.com/pierskarsenbarg/pulumi-fcknat",
			Publisher:         "Piers Karsenbarg",
		},
		ModuleMap: map[tokens.ModuleName]tokens.ModuleName{
			"pkg": "index", // required because the folder with everything in is "pkg"
		},
		Components: []infer.InferredComponent{
			infer.Component[*pkg.NatInstance, pkg.NatInstanceArgs, *pkg.NatInstanceState](),
		},
	})
}
